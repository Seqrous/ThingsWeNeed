using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Data.Household;
using ThingsWeNeed.Shared;
using Microsoft.Owin;
using System.Net.Http;
using Microsoft.AspNet.Identity;
using ThingsWeNeed.Service.Identity;

namespace ThingsWeNeed.Service.Controllers.Household
{
    [RoutePrefix("api/Households")]
    public class HouseholdApiController : ApiController
    {
        private HouseholdDaLogic householdLogic;
        private TwnContext context;

        public HouseholdApiController()
        {
            context = TwnContext.Create();
            householdLogic = new HouseholdDaLogic(context, User.Identity.GetUserId());
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if (ModelState.IsValid)
            {
                using (householdLogic)
                {
                    HouseholdDto dto = householdLogic.GetById(id);
                    return Ok(dto);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        // move maybe to user Api Controller
        [Route("")]
        // and change this to maybe api/User/{id}/Households
        public IHttpActionResult GetCollection()
        {
            if (ModelState.IsValid)
            {
                using (householdLogic)
                {
                    var householdDtoList = householdLogic.GetCollection();
                    return Ok(householdDtoList);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Update(int id, [FromBody] HouseholdDto dto)
        {
            if (ModelState.IsValid)
            {
                using (householdLogic)
                {
                    dto.HouseholdId = id;
                    var householdDto = householdLogic.Update(dto);
                    return Ok(householdDto);
                }   
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                using (householdLogic)
                {
                    HouseholdDto retDto = householdLogic.Delete(id);
                    return Ok(retDto);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody] HouseholdDto newHousehold)
        {
            if (ModelState.IsValid)
            {
                using (householdLogic)
                {
                    HouseholdDto householdDto = householdLogic.Create(newHousehold);

                    using (var manager = TwnUserManager.Create(null, HttpContext.Current.GetOwinContext()))
                    {
                        manager.JoinHousehold(User.Identity.GetUserId(), householdDto.HouseholdId);
                    }

                    return Ok(householdDto);

                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        public void InjectLogic(HouseholdDaLogic householdLogic)
        {
            this.householdLogic = householdLogic;
        }
    }
}