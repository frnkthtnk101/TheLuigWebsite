using Luig.Business.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Teaching.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Execute ([FromBody] string InputType, [FromBody] string InputRequest)
        {
            var response = new List<SqlPlayGroundRow>();
            if (InputType == "SQL")
            {
                var manager = new SQLPlayGroundManager();
                response = manager.GetPlayGroundResponse(InputRequest);
            }
            return Ok(response);
        }
    }
}
