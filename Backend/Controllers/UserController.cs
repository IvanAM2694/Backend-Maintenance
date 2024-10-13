using Application.DTO.Request;
using Application.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserManager userManager;
        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody] UserRequest userRequest)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            try
            {
                serviceResponse.Data = this.userManager.Create(userRequest);
                return Ok(serviceResponse);
            }
            catch (Exception ex)
            {
                return serviceResponse.AttachException(this, ex);
            }
        }

        [HttpPut]
        [Route("update/{guid}")]
        public IActionResult Update(Guid guid, [FromBody] UserRequest userRequest)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            try
            {
                serviceResponse.Data = this.userManager.Update(guid, userRequest);
                return Ok(serviceResponse);
            }
            catch (Exception ex)
            {
                return serviceResponse.AttachException(this, ex);
            }
        }

        [HttpDelete]
        [Route("delete/{guid}")]
        public IActionResult Delete(Guid guid)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            try
            {
                serviceResponse.Data = this.userManager.Delete(guid);
                return Ok(serviceResponse);
            }
            catch (Exception ex)
            {
                return serviceResponse.AttachException(this, ex);
            }
        }

        [HttpGet]
        [Route("byGUID")]
        public IActionResult GetByGUID(Guid guid)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            try
            {
                serviceResponse.Data = this.userManager.GetUserByGUID(guid);
                return Ok(serviceResponse);
            }
            catch (Exception ex)
            {
                return serviceResponse.AttachException(this, ex);
            }
        }

        [HttpGet]
        [Route("list")]
        public IActionResult ListAll()
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            try
            {
                serviceResponse.Data = this.userManager.GetUsers();
                return Ok(serviceResponse);
            }
            catch (Exception ex)
            {
                return serviceResponse.AttachException(this, ex);
            }
        }
    }
}
