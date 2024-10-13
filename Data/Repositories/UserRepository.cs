using Data.Models;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(MaintenanceContext maintenanceContext)
            : base(maintenanceContext)
        {
        }
        public User Create(User user, DbTransaction dbTransaction = null)
        {
            try
            {
                if (dbTransaction != null)
                    this.maintenanceContext.Database.UseTransaction(dbTransaction);

                this.maintenanceContext.Users.Add(user);
                this.maintenanceContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }

        public bool Delete(int userId, DbTransaction dbTransaction = null)
        {
            bool result = false;
            try
            {
                if (dbTransaction != null)
                    this.maintenanceContext.Database.UseTransaction(dbTransaction);

                User user = this.maintenanceContext.Users.Where(pr => pr.Id == userId).First();
                if (user != null)
                {
                    this.maintenanceContext.Users.Remove(user);
                    this.maintenanceContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public User GetUserByGuid(Guid userGUID, DbTransaction dbTransaction = null)
        {
            User user = null;
            try
            {
                if (dbTransaction != null)
                    this.maintenanceContext.Database.UseTransaction(dbTransaction);

                user = this.maintenanceContext.Users.FirstOrDefault(x => x.Guid.Equals(userGUID));
            }
            catch (Exception ex)
            {
            }

            return user;
        }

        public User GetUserByEmail(string email, DbTransaction dbTransaction = null)
        {
            User user = null;
            try
            {
                if (dbTransaction != null)
                    this.maintenanceContext.Database.UseTransaction(dbTransaction);

                user = this.maintenanceContext.Users.FirstOrDefault(x => x.Email.Equals(email));
            }
            catch (Exception ex)
            {
            }

            return user;
        }

        public IEnumerable<User> GetUsers(DbTransaction dbTransaction = null)
        {
            IEnumerable<User> users = null;
            try
            {
                if (dbTransaction != null)
                    this.maintenanceContext.Database.UseTransaction(dbTransaction);

                users = this.maintenanceContext.Users;
            }
            catch (Exception ex)
            {
            }

            return users;
        }

        public User Update(User user, DbTransaction dbTransaction = null)
        {
            try
            {
                if (dbTransaction != null)
                    this.maintenanceContext.Database.UseTransaction(dbTransaction);

                this.maintenanceContext.Users.Update(user);
                this.maintenanceContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }
    }
}
