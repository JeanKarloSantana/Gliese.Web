using Gliese.Entities;
using Gliese.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Interfaces.Domain
{
    public interface IAuthManager
    {
        Task<string> IsAuthenticated(User user);
    }
}
