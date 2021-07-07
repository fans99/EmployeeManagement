using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeManagement.CustomAuthorize;
using EmployeeManagement.Models;
using EmployeeManagement.Services;

namespace EmployeeManagement.Controllers
{
    [RoutePrefix("api/log")]
    [EmAuth(AllowPowerId = "999004")]
    public class LogController : ApiController
    {
        private readonly ILoggerRepository loggerRepository = new LoggerRepository();

        [Route("login")]
        public IHttpActionResult GetLoginLog()
        {
            return Json(new ResponseData()
            {
                Data = loggerRepository.GetAllToLoginLog()
            });
        }

        [Route("login")]
        public IHttpActionResult GetLoginLog(int logId)
        {
            return Json(new ResponseData()
            {
                Data = loggerRepository.GetToLoginLog(logId)
            });
        }

        [Route("login")]
        public IHttpActionResult DeleteLoginLog()
        {
            int result = loggerRepository.DeleteAllToLoginLog();
            return Json(new ResponseData()
            {
                Data = new
                {
                    result = result > 0,
                    count = result
                }
            });
        }

        [Route("login")]
        public IHttpActionResult DeleteLoginLog(int logId)
        {
            return Json(new ResponseData()
            {
                Data = loggerRepository.DeleteToLoginLog(logId)
            });
        }

        [Route("exception")]
        public IHttpActionResult GetExceptionLog()
        {
            return Json(new ResponseData()
            {
                Data = loggerRepository.GetAllToException()
            });
        }

        [Route("exception")]
        public IHttpActionResult GetExceptionLog(int exceptionId)
        {
            return Json(new ResponseData()
            {
                Data = loggerRepository.GetToException(exceptionId)
            });
        }

        [Route("exception")]
        public IHttpActionResult DeleteExceptionLog()
        {
            int result = loggerRepository.DeleteAllToException();
            return Json(new ResponseData()
            {
                Data = new
                {
                    result = result > 0,
                    count = result
                }
            });
        }

        [Route("exception")]
        public IHttpActionResult DeleteExceptionLog(int exceptionId)
        {
            return Json(new ResponseData()
            {
                Data = loggerRepository.DeleteToException(exceptionId)
            });
        }
    }
}
