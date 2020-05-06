using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Data.User;
using ThingsWeNeed.Shared;

using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using ThingsWeNeed.Data.Household;
using Microsoft.Ajax.Utilities;

namespace ThingsWeNeed.Controllers.Thing
{

    [Authorize]
    public class ThingsApiController : ApiController
    {
        private ThingDaLogic _logic;
        private TwnContext _context;
        private UserEntity _currentUser;


        public TwnContext DatabaseContext {
            get => _context ?? new TwnContext();
            set => _context = value;
        }

        public ThingDaLogic Logic {
            get => _logic ?? new ThingDaLogic(DatabaseContext, User.Identity.GetUserId());
            set => _logic = value;
        }

        public ThingsApiController() : base() {
        }

        [HttpGet]
        [Route("api/Things/{id}")]
        public IHttpActionResult Get(int id) {
            if (ModelState.IsValid)
            {
                using (Logic)
                {
                    ThingDto dto = Logic.GetById(id);

                    //dto.Household = new LinkDto($"api/Things/{id}/Household", "houshold", "GET");
                    //dto.Links.Add(new LinkDto($"api/Things/{id}", "self", "GET"));
                    //dto.Links.Add(new LinkDto($"api/Things/{id}", "create-thing", "POST"));
                    //dto.Links.Add(new LinkDto($"api/Things/{id}", "update-thing", "PUT"));
                    //dto.Links.Add(new LinkDto($"api/Things/{id}", "delete-thing", "DELETE"));

                    return Ok(dto);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("api/Things")]
        public IHttpActionResult GetCollection() {
            return Ok(Logic.GetCollection());
        }

        [HttpPost]
        [Route("api/Things")]
        public IHttpActionResult Create([FromBody] ThingDto dto) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var retDto = Logic.Create(dto);

            return Ok(retDto);


            //   if (ModelState.IsValid)
            //{
            //    using (logic)
            //    {
            //        logic.Create(dto.Name, dto.HouseholdId,  dto.Show, dto.Needed, dto.DefaultPrice);
            //    }
            //    return Ok(dto);
            //}
            //else
            //{
            //    return BadRequest(ModelState);
            //}
            //return null;
        }


        [HttpPut]
        [Route("api/Things/{id}")]
        public IHttpActionResult Update(int id, [FromBody] ThingDto dto)
        {
            if (ModelState.IsValid)
            {
                using (_logic)
                {
                    dto.ThingId = id;
                    var thingDto = _logic.Update(dto);
                    return Ok(thingDto);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        

        [HttpDelete]
        [Route("api/Things/{id}")]
        public IHttpActionResult Delete(int id) {
            //if (ModelState.IsValid)
            //{
            //    using (logic)
            //    {
            //        ThingDto dto = logic.Delete(id);
            //        return Ok(dto);
            //    }
            //}
            //else
            //{
            //    return BadRequest(ModelState);
            //}

            return null;
        }

        //public void InjectLogic(ThingDaLogic logic) {
        //    this.logic = logic;
        //}

    }
}