using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace TestApi.Admin.Filter
{
    public class CustomExceptionHandler: ExceptionHandler
    {

        private class ErrorInformation
        {
            public string Message { get; set; }
            public DateTime ErrorDate { get; set; }
            public string ExceptionUrl { get; set; }
            public string ExceptionMessage { get; set; }
            public string Method { get; set; }
        }

        public override void Handle(ExceptionHandlerContext context)
        {

            //Return a DTO representing what happened
            context.Result = new ResponseMessageResult(context.Request.CreateResponse(HttpStatusCode.InternalServerError,
            new ErrorInformation
            {
                Message = "We apologize but an unexpected error occured. Please try again later.",
                ExceptionUrl = context.Request.RequestUri.ToString(),
                ExceptionMessage = context.ExceptionContext.Exception.Message.ToString(),
                Method = context.Request.Method.ToString(),
                ErrorDate = DateTime.UtcNow
            }));

            //This is commented out, but could also serve the purpose if you wanted to only return some text directly, rather than JSON that the front end will bind to.
            //context.Result = new ResponseMessageResult(context.Request.CreateResponse(HttpStatusCode.InternalServerError, "We apologize but an unexpected error occured. Please try again later."));
        }
    }
}