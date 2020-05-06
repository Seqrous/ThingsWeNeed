using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ThingsWeNeed.Data.User;

using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Service.Controllers
{
    public class RootApiController : ApiController
    {
        [HttpGet]
        [Route("api")]
        public IHttpActionResult Root(UserEntity user) {
            return Ok(new { links = new LinkDto[] {
                new LinkDto("api", "self", "GET"),
                new LinkDto("api/Things", "things_collection", "GET")
            }});
        }
    }
}