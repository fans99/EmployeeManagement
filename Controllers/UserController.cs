using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeManagement.Services;
using EmployeeManagement.Models;
using System.Web.Http.Cors;
using EmployeeManagement.CustomAuthorize;
using EmployeeManagement.Tools;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Web;

namespace EmployeeManagement.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserRepository userRepository = new UserRepository();
        private readonly ILoggerRepository loggerRepository = new LoggerRepository();

        [EmAuth]
        [HttpGet]
        [Route("login")]
        public IHttpActionResult Login()
        {
            return Json(new ResponseData()
            {
                Data = new
                {
                    UserId = (User.Identity as UserIdentity).Id,
                    UserName = User.Identity.Name,
                    IsLogin = true
                }
            });
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(JObject keyValues)
        {
            object validateCode = HttpContext.Current.Session["ValidateCode"];
            EmLoginLog loginLog = new EmLoginLog()
            {
                Account = keyValues["UserAccount"].Value<string>(),
                Pwd = keyValues["UserPwd"].Value<string>(),
                LoginIp = HttpContext.Current.Request.UserHostAddress,
                LoginTime = DateTime.Now
            };

            if (validateCode == null || !validateCode.ToString().Equals(keyValues["ValidateCode"].Value<string>()))
                return Json(new ResponseData()
                {
                    Code = 412,
                    ErrorMessage = "验证码不正确"
                });               

            EmUser result = userRepository.Find(keyValues["UserAccount"].Value<string>(), keyValues["UserPwd"].Value<string>());
            if (result != null)
            {
                Dictionary<string, object> payload = new Dictionary<string, object>
                {
                    { "UserId", result.UserId },
                    { "UserAccount", result.UserAccount }
                };
                string token = JwtTool.Encode(payload);

                loginLog.Result = "成功";
                loggerRepository.InsertToLoginLog(loginLog);
                return Json(new ResponseData()
                {
                    Data = new
                    {
                        token
                    }
                });
            }
            else
            {
                loginLog.Result = "失败";
                loggerRepository.InsertToLoginLog(loginLog);
                return Json(new ResponseData()
                {
                    Code = 401,
                    ErrorMessage = "用户名或密码不正确"
                });
            }
            
        }

        [EmAuth]
        [HttpGet]       
        [Route("Info")]
        public IHttpActionResult TokenInfo()
        {
            return Json(new {
                UserAccount = User.Identity.Name,
                UserId = (User.Identity as UserIdentity).Id
            });
        }

        [EmAuth(AllowPowerId = "999003")]
        public IHttpActionResult Get()
        {
            IEnumerable<EmUser> userList = userRepository.GetAllUser();
            List<UserPageModel> result = new List<UserPageModel>();
            foreach (EmUser user in userList)
            {
                result.Add(UserPageModel.CreateModel(user));
            }

            return Json(new ResponseData()
            {
                Data = result
            });
        }

        [EmAuth(AllowPowerId = "999003")]
        public IHttpActionResult Get(int id)
        {
            return Json(new ResponseData()
            {
                Data = UserPageModel.CreateModel(userRepository.GetUser(id))
            });
        }

        [EmAuth(AllowPowerId = "999003")]
        public IHttpActionResult Post([FromBody] EmUser newUser)
        {
            int result = userRepository.Insert(newUser);
            return Json(new ResponseData()
            {
                Data = result == 1
            });
        }

        [EmAuth(AllowPowerId = "999003")]
        public IHttpActionResult Put(int id, [FromBody] EmUser updateUser)
        {
            updateUser.UserId = id;
            EmUser user = userRepository.Update(updateUser);
            return Json(new ResponseData()
            {
                Data = new
                {
                    updateUser = user,
                    result = user != null
                }
            });
        }

        [Route("status")]
        [EmAuth(AllowPowerId = "999003")]
        public IHttpActionResult Put(int id, bool status)
        {
            return Json(new ResponseData()
            {
                Data = userRepository.UpdateStatus(id, status)
            });
        }

        [EmAuth(AllowPowerId = "999003")]
        public IHttpActionResult Delete(int id)
        {
            EmUser user = userRepository.Delete(id);
            return Json(new ResponseData()
            {
                Data = new
                {
                    deleteUser = user,
                    result = user != null
                }
            });
        }

        [HttpPost]
        [Route("DeleteMultiple")]
        [EmAuth(AllowPowerId = "999003")]      
        public IHttpActionResult DeleteMultiple(JObject keyValues)
        {
            int result = userRepository.DeleteMultiple(keyValues["UserId"].Values<int>());
            return Json(new ResponseData()
            {
                Data = new
                {
                    count = result,
                    result = result > 0
                }
            });
        }
    }
}
