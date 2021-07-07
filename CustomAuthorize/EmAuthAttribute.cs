using EmployeeManagement.Services;
using EmployeeManagement.Tools;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;


namespace EmployeeManagement.CustomAuthorize
{
    public class EmAuthAttribute : Attribute, IAuthorizationFilter
    {
        private static readonly IPowerRepository powerRepository = new PowerRepository();
        private static readonly IUserRepository userRepository = new UserRepository();
        public bool AllowMultiple { get; }

        public string AllowPowerId { get; set; }

        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            IEnumerable<string> tokens;
            if (!actionContext.Request.Headers.TryGetValues("token", out tokens))
            {
                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                    Content = new StringContent("用户未登录", System.Text.Encoding.UTF8),
                };
            }

            Dictionary<string, object> userData = JwtTool.Decode(tokens.FirstOrDefault());
            int userId = int.Parse(userData["UserId"].ToString());
            string userName = userRepository.GetUser(userId).UserRealName;
            (actionContext.ControllerContext.Controller as ApiController).User = new ApplicationUser(userId, userName);

            if (!string.IsNullOrEmpty(AllowPowerId))
            {
                var powerList = powerRepository.GetAllPower(userId);
                foreach (var item in powerList)
                {
                    if (item.PowerId.Equals(AllowPowerId))
                        return await continuation();
                }

                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                    Content = new StringContent("用户权限不足", System.Text.Encoding.UTF8)
                };
            }

            return await continuation();
        }
    }
}

