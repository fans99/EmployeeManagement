using EmployeeManagement.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EmployeeManagement.CustomAuthorize
{
    public class LoginAuthAttribute : Attribute, IAuthorizationFilter
    {
        public bool AllowMultiple { get; }

        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            IEnumerable<string> tokens;
            if (actionContext.Request.Headers.TryGetValues("token", out tokens))
            {
                Dictionary<string, object> userData = JwtTool.Decode(tokens.FirstOrDefault());
                int userId = int.Parse(userData["UserId"].ToString());
                string userAccount = userData["UserAccount"].ToString();
                (actionContext.ControllerContext.Controller as ApiController).User = new ApplicationUser(userId, userAccount);

                return await continuation();
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
        }
    }
}