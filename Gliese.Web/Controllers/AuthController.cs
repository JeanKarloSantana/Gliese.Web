using Gliese.Domain.Auth;
using Gliese.Entities;
using Gliese.Entities.DTO;
using Gliese.Interfaces.Domain;
using Gliese.Interfaces.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gliese.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthManager _auth;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(
            IAuthManager auth, 
            UserManager<User> userManager, 
            RoleManager<Role> roleManager,
            IUnitOfWork unitOfWork,
            SignInManager<User> signInManager)
        {
            _auth = auth;
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]        
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto) 
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(dto.Email);

                if (user != null) return StatusCode(400, "That email is already registered");

                Person person = _unitOfWork.Person.CreatePersonByRegisterDto(dto);

                _unitOfWork.Complete();

                var newUser = new User
                {
                    Id = person.Id,
                    Email = dto.Email,
                    EmailConfirmed = true,
                    UserName = dto.UserName
                };

                var createUser = await _userManager.CreateAsync(newUser, dto.Password);
                
                if (!createUser.Succeeded) { return StatusCode(400, createUser.Errors.ToList()); }

                foreach(int role in dto.Roles)
                {
                    var getRole = await _roleManager.FindByIdAsync(role.ToString());

                    if (getRole == null) return StatusCode(400, String.Format($"The Role with the Id {role} does not exist"));

                    var addRole = await _userManager.AddToRoleAsync(newUser, getRole.Name);

                    if (!addRole.Succeeded) return StatusCode(500, String.Format($"The Role {role} couldn't be added"));
                };

                return StatusCode(201, "Nuevo Usuario Registrado");
                
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            try
            {
                User user = await _userManager.FindByNameAsync(dto.Username);

                if (user == null) return StatusCode(401, "User not found");

                var result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, isPersistent: false, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    var Token = await _auth.IsAuthenticated(user);

                    HttpContext.Session.SetString("Token", Token);

                    HttpContext.Response.Headers.Add("Authorization", Token);
                    HttpContext.Response.Headers.Add("access-control-expose-headers", new[] { "Authorization" });
                    return StatusCode(200, new { result = "Login Successfully" });
                }

                return StatusCode(200, "You Just logged");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
