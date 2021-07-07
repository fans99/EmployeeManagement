using EmployeeManagement.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Net.Http.Headers;

namespace EmployeeManagement.Controllers
{
    [RoutePrefix("api/image")]
    public class ImageController : ApiController
    {
        [HttpGet]
        [Route("validate")]
        public HttpResponseMessage Validate()
        {
            NetValidateCode netValidateCode = new NetValidateCode();
            byte[] imgBytes = netValidateCode.CreateImage();           
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(imgBytes);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/gif");

            HttpContext.Current.Session["ValidateCode"] = netValidateCode.RandomCode;
            return result;
        }
    }
}
