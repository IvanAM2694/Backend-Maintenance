using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers(DbTransaction dbTransaction = null);
        User GetUserByGuid(Guid userGUID, DbTransaction dbTransaction = null);
        User GetUserByEmail(string email, DbTransaction dbTransaction = null);
        User Create(User user, DbTransaction dbTransaction = null);
        User Update(User user, DbTransaction dbTransaction = null);
        bool Delete(int userId, DbTransaction dbTransaction = null);
    }
}
