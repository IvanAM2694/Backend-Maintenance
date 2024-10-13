using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Backend.Models
{
    public class ServiceResponse
    {
        public static String ERROR = "E";
        public static String WARNING = "W";
        public static String SUCCESSFUL = "S";
        public static String INFO = "I";


        public object Data { get; set; }
        public ErrorResponse Error { get; set; }
        public String ResultType { get; set; }
        public ServiceResponse()
        {
            this.ResultType = SUCCESSFUL;
        }
        public ObjectResult AttachException(ControllerBase controller, Exception ex)
        {
            if(ex is Application.Exceptions.ManagerException applicationException)
            {
                HttpStatusCode statusCode = applicationException.StatusCode;
                switch (statusCode) { 
                    case HttpStatusCode.NotFound:
                        return controller.NotFound(ex.Message);
                }

                return controller.Problem(ex.Message);
            }
            else
                return controller.Problem(ex.Message);

            /*if (ex is WSCException)
            {
                this.ResultType = ERROR;
                this.Error = new ErrorResponse(ex.Message);
                return controller.Ok(this);
            }
            else
                return controller.Problem(ex.Message);*/
        }
    }
}
