using System;
using System.Net;

namespace Application.Exceptions
{
    public class ManagerException : Exception
    {
        public HttpStatusCode StatusCode;
        public ManagerException(string message, HttpStatusCode httpStatus) :
            base(message)
        {
            this.StatusCode = httpStatus;
        }
    }
}
