using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace TestApi.Admin.Filter
{
    public class AuthenticationFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decededToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string userName = decededToken.Substring(0, decededToken.IndexOf(":"));
                string userPassword = decededToken.Substring(decededToken.IndexOf(":") + 1);

                if (userName == "himu" && userPassword == "himu")
                {
                    //authorized
                }
                else
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}