using Application.DTO.Request;
using Application.DTO.Response;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthenticationManager
    {
        public UserResponse Login(LoginRequest loginRequest, DbTransaction dbTransaction = null, bool isRootService = true);
    }
}
