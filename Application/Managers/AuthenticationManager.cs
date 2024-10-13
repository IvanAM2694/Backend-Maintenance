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
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IUserRepository userRepository;
        private readonly ITransactionManager transactionManager;
        public AuthenticationManager(IUserRepository userRepository, ITransactionManager transactionManager)
        {
            this.transactionManager = transactionManager;
            this.userRepository = userRepository;
        }

        public UserResponse Login(LoginRequest loginRequest, DbTransaction dbTransaction = null, bool isRootService = true)
        {
            UserResponse userResponse = null;
            this.transactionManager.SetDbTransaction(dbTransaction);
            try
            {
                this.transactionManager.BeginTransaction(isRootService);
                User user = this.userRepository.GetUserByEmail(loginRequest.Email, this.transactionManager.GetTransaction());
                if (user == null)
                    throw new ManagerException($@"El usuario no existe", System.Net.HttpStatusCode.NotFound);

                if (StringCipher.Verify(loginRequest.Password, user.Password))
                {
                    userResponse = UserMapper.ToUserResponse(user);
                }

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
