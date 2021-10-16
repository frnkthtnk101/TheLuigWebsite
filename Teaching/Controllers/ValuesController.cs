using Luig.Business.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Teaching.Models;

namespace Teaching.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Execute ([FromBody] ExecuteQueryRequest request)
        {
            var response = new List<object>();
            if (request.InputType == "SQL")
            {
                var manager = new SQLPlayGroundManager();
                response = manager.GetPlayGroundResponse(request.InputRequest);
            }
            return Ok(response);
        }
    }
}
