using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeManagement.Services;
using EmployeeManagement.Models;
using EmployeeManagement.CustomAuthorize;
using Newtonsoft.Json.Linq;

namespace EmployeeManagement.Controllers
{
    [RoutePrefix("api/department")]
    public class DepartmentController : ApiController
    {
        private readonly IDepartmentRepository departmentRepository = new DepartmentRepository();

        
        public IHttpActionResult Get()
        {
            return Json(new ResponseData()
            {
                Data = departmentRepository.GetAllDepartment()
            });
        }

        [EmAuth]
        public IHttpActionResult Get(string id)
        {
            return Json(new ResponseData()
            {
                Data = departmentRepository.GetDepartment(id)
            });
        }

        [EmAuth(AllowPowerId = "999001")]
        public IHttpActionResult Post([FromBody] EmDepartment newDepartment)
        {
            if (string.IsNullOrEmpty(newDepartment.DepartmentId))
                return Json(new ResponseData()
                {
                    Code = 500
                });

            int result = departmentRepository.Insert(newDepartment);
            return Json(new ResponseData()
            {
                Data = result == 1
            });
        }

        [EmAuth(AllowPowerId = "999001")]
        public IHttpActionResult Put(string id, [FromBody] EmDepartment updateDepartment)
        {
            updateDepartment.DepartmentId = id;
            EmDepartment department = departmentRepository.Update(updateDepartment);
            return Json(new ResponseData()
            {
                Data = new
                {
                    updateDepartment = department,
                    result = department != null
                }
            });
        }

        [EmAuth(AllowPowerId = "999001")]
        public IHttpActionResult Delete(string id)
        {
            EmDepartment department = departmentRepository.Delete(id);
            return Json(new ResponseData()
            {
                Data = new
                {
                    deleteDepartment = department,
                    result = department != null
                }
            });
        }

        [HttpPost]
        [Route("DeleteMultiple")]
        [EmAuth(AllowPowerId = "999001")]      
        public IHttpActionResult DeleteMultiple(JObject keyValues)
        {
            int result = 0;

            foreach (string item in keyValues["DepartmentId"].Values<string>())
            {
                if (departmentRepository.Delete(item) != null)
                    result += 1;
            }

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
