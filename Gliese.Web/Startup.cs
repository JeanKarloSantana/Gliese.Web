using Gliese.DAL.SQL;
using Gliese.Domain.ApiURL;
using Gliese.Domain.Auth;
using Gliese.Domain.ExchangeRateManager;
using Gliese.Domain.themis;
using Gliese.Entities;
using Gliese.Entities.Messages;
using Gliese.Entities.Token;
using Gliese.Interfaces.Domain;
using Gliese.Interfaces.Generic;
using Gliese.Interfaces.Service;
using Gliese.Persistance.Generic;
using Gliese.Services.Auth;
using Gliese.Services.ExchangeRate;
using Gliese.Services.JsonDeserialize;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;


namespace Gliese.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;

            });/*.ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });*/

            services.AddDbContext<DeimosDbContext>(options => options
                .UseSqlServer(("Name=DeimosDbContext")));

            // ===== Add Identity ========
            services.AddIdentity<User, Role>(options =>
            {
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);                
            })
            .AddRoles<Role>()
            .AddRoleManager<RoleManager<Role>>()
            .AddEntityFrameworkStores<DeimosDbContext>()
            .AddDefaultTokenProviders();

            // ===== Add Jwt Authentication ========
            services.Configure<Token>(Configuration.GetSection("tokenManagement"));   
            
            var token = Configuration.GetSection("tokenManagement").Get<Token>();
            
            var secret = Encoding.ASCII.GetBytes(token.Secret);
              
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims            

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secret),
                    ValidIssuer = token.Issuer,
                    ValidAudience = token.Issuer,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero // remove delay of token when expire
                };
            });
           
            services.AddSession(options =>
            {
                options.Cookie.Name = "TokenStorage";
                options.IdleTimeout = TimeSpan.FromHours(token.AccessExpiration);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(1);
            });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gliese.Web", Version = "v1" });
            });

            services.AddCors();            

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAuthManager, AuthManager>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<IExchangeRateManager, ExchangeRateManager>();
            services.AddTransient<IExchangeRateService, ExchangeRateService>();
            services.AddTransient<IJsonDeserializeService, JsonDeserializeService>();
            services.AddTransient<IWorkedTaskManager, WorkedTaskManager>();
            services.AddTransient<ExchangeRateURL>();
            services.AddTransient<ErrorMessages>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gliese.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseSession();

            app.UseAuthorization();

            app.UseCors(options =>
                options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
