using EmployeeManagement.CustomAuthorize;
using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagement.Controllers
{
    [RoutePrefix("api/role")]
    public class RoleController : ApiController
    {
        private readonly IRoleRepository roleRepository = new RoleRepository();

        [EmAuth]
        public IHttpActionResult Get()
        {
            return Json(new ResponseData()
            {
                Data = roleRepository.GetAllRole()
            });
        }

        [EmAuth]
        public IHttpActionResult Get(int id)
        {
            return Json(new ResponseData()
            {
                Data = roleRepository.GetRole(id)
            });
        }

        [EmAuth(AllowPowerId = "999002")]
        public IHttpActionResult Post([FromBody] EmRole newRole)
        {
            int result = roleRepository.Insert(newRole);
            return Json(new ResponseData()
            {
                Data = result == 1
            });
        }

        [EmAuth(AllowPowerId = "999002")]
        public IHttpActionResult Put(int id, [FromBody] EmRole updateRole)
        {
            updateRole.RoleId = id;
            EmRole role = roleRepository.Update(updateRole);
            return Json(new ResponseData()
            {
                Data = new
                {
                    updateUser = role,
                    result = role != null
                }
            });
        }

        [EmAuth(AllowPowerId = "999002")]
        public IHttpActionResult Delete(int id)
        {
            EmRole role = roleRepository.Delete(id);
            return Json(new ResponseData()
            {
                Data = new
                {
                    deleteRole = role,
                    result = role != null
                }
            });
        }

        [HttpPost]
        [Route("DeleteMultiple")]
        [EmAuth(AllowPowerId = "999002")]
        public IHttpActionResult DeleteMultiple(JObject keyValues)
        {
            int result = roleRepository.DeleteMultiple(keyValues["RoleId"].Values<int>());
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
