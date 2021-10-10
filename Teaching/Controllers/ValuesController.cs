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
        public IHttpActionResult ([FromBody] string InputType, [FromBody] string InputRequest)
        {
            if (InputType == "SQL")
            {

            }
            else
                ok
        }
    }
}
