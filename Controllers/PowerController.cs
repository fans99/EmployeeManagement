using EmployeeManagement.CustomAuthorize;
using EmployeeManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeManagement.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace EmployeeManagement.Controllers
{
    [RoutePrefix("api/power")]
    public class PowerController : ApiController
    {
        private readonly IPowerRepository powerRepository = new PowerRepository();

        [EmAuth]
        public IHttpActionResult Get()
        {
            IEnumerable<EmPower> result = powerRepository.GetAllPower().Distinct();
            return Json(new ResponseData()
            {
                Data = result
            });
        }

        [EmAuth]
        public IHttpActionResult Get(int id)
        {
            IEnumerable<EmPower> result = powerRepository.GetAllPower(id).Distinct();
            return Json(new ResponseData()
            {
                Data = result
            });
        }

        [EmAuth(AllowPowerId = "999003")]
        [HttpGet]
        [Route("user")]
        public IHttpActionResult GetToUser(int userId)
        {
            IEnumerable<EmPower> result = powerRepository.GetPowerInUser(userId).Distinct();
            return Json(new ResponseData()
            {
                Data = result
            });
        }

        [EmAuth(AllowPowerId = "999002")]
        [HttpGet]
        [Route("role")]
        public IHttpActionResult GetToRole(int roleId)
        {
            IEnumerable<EmPower> result = powerRepository.GetPowerInRole(roleId).Distinct();
            return Json(new ResponseData()
            {
                Data = result
            });
        }

        [EmAuth(AllowPowerId = "999003")]
        [HttpPost]
        [Route("user")]
        public IHttpActionResult SetToUser(JObject keyValues)
        {
            try
            {
                int result = powerRepository.SetPowerToUser(keyValues["UserId"].Value<int>(), keyValues["PowerList"].Values<string>());

                return Json(new ResponseData()
                {
                    Data = result
                });
            }
            catch (Exception error)
            {
                return Json(new ResponseData()
                {
                    Code = 500,
                    ErrorMessage = error.Message
                });
            }
        }

        [EmAuth(AllowPowerId = "999002")]
        [HttpPost]
        [Route("role")]
        public IHttpActionResult SetToRole(JObject keyValues)
        {
            try
            {
                int result = powerRepository.SetPowerToRole(keyValues["RoleId"].Value<int>(), keyValues["PowerList"].Values<string>());

                return Json(new ResponseData()
                {
                    Data = result
                });
            }
            catch (Exception error)
            {
                return Json(new ResponseData()
                {
                    Code = 500,
                    ErrorMessage = error.Message
                });
            }
        }

    }
}
