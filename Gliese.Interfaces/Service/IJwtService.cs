using Gliese.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Interfaces.Service
{
    public interface IJwtService
    {
        Task<string> GenerateJwtToken(User user);
    }
}
