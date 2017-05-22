using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SortingAlgorithmApi.Controllers
{
    [RoutePrefix("api/TestController")]
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("TestConnection")]
        public HttpResponseMessage TestConnection()
        {
            var returnObj = new
            {
                message = "hello"
            };
            return Request.CreateResponse(HttpStatusCode.OK, returnObj);
        }
    }
}
