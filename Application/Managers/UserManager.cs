using Application.DTO.Request;
using Application.DTO.Response;
using Application.Exceptions;
using Application.Interfaces;
using Application.Mapper;
using Data.Interfaces;
using Data.Models;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Application.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepository;
        private readonly ITransactionManager transactionManager;
        public UserManager(IUserRepository userRepository, ITransactionManager transactionManager)
        {
            this.transactionManager = transactionManager;
            this.userRepository = userRepository;
        }
        public bool Delete(Guid userGUID, DbTransaction dbTransaction = null, bool isRootService = true)
        {
            bool response = false;
            this.transactionManager.SetDbTransaction(dbTransaction);
            try
            {
                this.transactionManager.BeginTransaction(isRootService);
                User user = this.userRepository.GetUserByGuid(userGUID, this.transactionManager.GetTransaction());
                if (user == null)
                    throw new ManagerException($@"El usuario no existe", System.Net.HttpStatusCode.NotFound);

                this.userRepository.Delete(user.Id, this.transactionManager.GetTransaction());
                response = true;

                this.transactionManager.CommitTransaction(isRootService);
            }
            catch (Exception ex)
            {
                this.transactionManager.RollbackTransaction(isRootService);
                throw ex;
            }

            return response;
        }

        public UserResponse GetUserByGUID(Guid userGUID, DbTransaction dbTransaction = null, bool isRootService = true)
        {
            UserResponse userResponse = null;
            this.transactionManager.SetDbTransaction(dbTransaction);
            try
            {
                this.transactionManager.BeginTransaction(isRootService);
                User user = this.userRepository.GetUserByGuid(userGUID, this.transactionManager.GetTransaction());
                if (user == null)
                    throw new ManagerException($@"El usuario no existe", System.Net.HttpStatusCode.NotFound);

                userResponse = UserMapper.ToUserResponse(user);

                this.transactionManager.CommitTransaction(isRootService);
            }
            catch (Exception ex)
            {
                this.transactionManager.RollbackTransaction(isRootService);
                throw ex;
            }

            return userResponse;
        }

        public List<UserResponse> GetUsers(DbTransaction dbTransaction = null, bool isRootService = true)
        {
            List<UserResponse> response = null;
            this.transactionManager.SetDbTransaction(dbTransaction);
            try
            {
                this.transactionManager.BeginTransaction(isRootService);

                IEnumerable<User> users = this.userRepository.GetUsers(this.transactionManager.GetTransaction());

                response = new List<UserResponse>();
                foreach (User user in users)
                {
                    UserResponse userResponse = UserMapper.ToUserResponse(user);
                    response.Add(userResponse);
                }

                this.transactionManager.CommitTransaction(isRootService);
            }
            catch (Exception ex)
            {
                this.transactionManager.RollbackTransaction(isRootService);
                throw ex;
            }

            return response;
        }

        public UserResponse Update(Guid userGUID, UserRequest userRequest, DbTransaction dbTransaction = null, bool isRootService = true) 
        {
            UserResponse userResponse = null;
            this.transactionManager.SetDbTransaction(dbTransaction);
            try
            {
                this.transactionManager.BeginTransaction(isRootService);
                User user = this.userRepository.GetUserByGuid(userGUID, this.transactionManager.GetTransaction());
                if (user == null)
                    throw new ManagerException($@"El usuario no existe", System.Net.HttpStatusCode.NotFound);

                user.Name = userRequest.Name;
                user.LastName = userRequest.LastName;
                user.BirthDate = userRequest.BirthDate;
                user.Email = userRequest.Email;
                user.Gender = userRequest.Gender;
                user.ChangedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc); ;

                user = this.userRepository.Update(user, this.transactionManager.GetTransaction());

                userResponse = UserMapper.ToUserResponse(user);

                this.transactionManager.CommitTransaction(isRootService);
            }
            catch (Exception ex)
            {
                this.transactionManager.RollbackTransaction(isRootService);
                throw ex;
            }

            return userResponse;
        }

        public UserResponse Create(UserRequest userRequest, DbTransaction dbTransaction = null, bool isRootService = true)
        {
            UserResponse userResponse = null;
            this.transactionManager.SetDbTransaction(dbTransaction);
            try
            {
                this.transactionManager.BeginTransaction(isRootService);
                User user  = UserMapper.ToUser(userRequest);
                user.Password = StringCipher.Encrypt(userRequest.Password);
                user.Guid = Guid.NewGuid();
                user.CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

                user = this.userRepository.Create(user, this.transactionManager.GetTransaction());

                userResponse = UserMapper.ToUserResponse(user);

                this.transactionManager.CommitTransaction(isRootService);
            }
            catch (Exception ex)
            {
                this.transactionManager.RollbackTransaction(isRootService);
                throw ex;
            }

            return userResponse;
        }
    }
}
