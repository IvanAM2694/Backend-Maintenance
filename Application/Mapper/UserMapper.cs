using Application.DTO.Request;
using Application.DTO.Response;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class UserMapper
    {
        public static UserResponse ToUserResponse(User user)
        {
            UserResponse response = new UserResponse();
            response.Gender = user.Gender;
            response.Guid = user.Guid;
            response.Email = user.Email;
            response.Name = user.Name;
            response.LastName = user.LastName;
            response.BirthDate = user.BirthDate;

            return response;
        }

        public static User ToUser(UserRequest request)
        {
            User user = new User();
            user.Email = request.Email;
            user.Name = request.Name;
            user.LastName = request.LastName;
            user.BirthDate = request.BirthDate;
            user.Gender = request.Gender;

            return user;
        }
    }
}
