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
    public interface IUserManager
    {
        List<UserResponse> GetUsers(DbTransaction dbTransaction = null, bool isRootService = true);
        UserResponse Create(UserRequest userRequest, DbTransaction dbTransaction = null, bool isRootService = true);
        UserResponse Update(Guid userGUID, UserRequest userRequest, DbTransaction dbTransaction = null, bool isRootService = true);
        UserResponse GetUserByGUID(Guid userGUID, DbTransaction dbTransaction = null, bool isRootService = true);
        bool Delete(Guid userGUID, DbTransaction dbTransaction = null, bool isRootService = true);
    }
}
