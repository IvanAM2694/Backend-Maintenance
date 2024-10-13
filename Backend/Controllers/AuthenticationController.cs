using Application.DTO.Request;
using Application.DTO.Response;
using Application.Interfaces;
using Backend.Helpers;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationManager authenticationManager;
        private JwtHelper jwtHelper;
        public AuthenticationController(IAuthenticationManager authenticationManager, IConfiguration configuration)
        {
            this.authenticationManager = authenticationManager;
            this.jwtHelper = new JwtHelper(configuration);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Save([FromBody] LoginRequest loginRequest)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            try
            {
                UserResponse userResponse = this.authenticationManager.Login(loginRequest);

                if (userResponse == null)
                    return Unauthorized();

                serviceResponse.Data = this.jwtHelper.GenerateJwtToken(userResponse);
                return Ok(serviceResponse);
            }
            catch (Exception ex)
            {
                return serviceResponse.AttachException(this, ex);
            }
        }

    }
}
