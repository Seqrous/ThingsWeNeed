using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThingsWeNeed.Data.Wish;
using ThingsWeNeed.Shared;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;

namespace ThingsWeNeed.Service.Controllers.Wish
{
    [Authorize]
    public class WishApiController : ApiController
    {
        private WishLogic logic;

        public WishApiController()
        {
            logic = new WishLogic();
        }

        [HttpGet]
        [Route("api/Wish/{id}")]
        public IHttpActionResult Get(int id)
        {
            if (ModelState.IsValid)
            {
                using (logic)
                {
                    WishDto dto = logic.GetById(id);
                    dto.User = new LinkDto($"api/Wishes/{id}/UserId", "user", "GET");
                    dto.Links.Add(new LinkDto($"api/Wishes/{id}", "self", "GET"));
                    dto.Links.Add(new LinkDto($"api/Wishes/{id}", "create-wish", "POST"));
                    dto.Links.Add(new LinkDto($"api/Wishes/{id}", "update-wish", "PUT"));
                    dto.Links.Add(new LinkDto($"api/Wishes/{id}", "delete-wish", "DELETE"));
                    return Ok(dto);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet]
        [Route("api/Wishes")]
        public IHttpActionResult GetCollection()
        {
            if (ModelState.IsValid)
            {
                using (logic)
                {
                    var dtoList = logic.GetCollection();

                    foreach (WishDto dto in dtoList)
                    {
                        dto.Links.Add(new LinkDto($"api/Wishes/{dto.WishId}", "self", "GET"));
                        dto.Links.Add(new LinkDto($"api/Wishes/{dto.WishId}", "create-wish", "POST"));
                        dto.Links.Add(new LinkDto($"api/Wishes/{dto.WishId}", "update-wish", "PUT"));
                        dto.Links.Add(new LinkDto($"api/Wishes/all", "delete-wish", "DELETE"));

                    }

                    return Ok(dtoList);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("api/Wishes/{userId}")]
        public IHttpActionResult GetCollection(string userId)
        {

            IHttpActionResult result;

            if (ModelState.IsValid)
            {
                using (logic)
                {
                    var dtoList = logic.GetCollectionByUserId(userId);

                    foreach (WishDto dto in dtoList)
                    {
                        dto.Links.Add(new LinkDto($"api/Wishes/{dto.WishId}", "self", "GET"));
                        dto.Links.Add(new LinkDto($"api/Wishes/{dto.WishId}", "create-wish", "POST"));
                        dto.Links.Add(new LinkDto($"api/Wishes/{dto.WishId}", "update-wish", "PUT"));
                        dto.Links.Add(new LinkDto($"api/Wishes/all", "delete-wish", "DELETE"));
                    }

                    result = Ok(dtoList);
                }
            }
            else
            {
                result = BadRequest(ModelState);
            }
            

            return result;
        }

        [HttpPost]
        [Route("api/Wishes")]
        public IHttpActionResult Create(WishDto dto)
        {
            if (ModelState.IsValid)
            {
                using (logic)
                {
                    dto.Show = true;
                    dto.MadeById = Request.GetOwinContext().Authentication.User.Identity.GetUserId();
                    dto.MadeOn = DateTime.Now;
                    dto.GrantedOn = null;

                    logic.Create(dto);
                    return Ok(dto);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("api/Wishes/{id}")]
        public IHttpActionResult Update(int id)
        {
            if (ModelState.IsValid)
            {
                using (logic)
                {
                    WishDto dto = logic.Update(id);
                    return Ok(dto);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpDelete]
        [Route("api/Wishes/{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                using (logic)
                {
                    WishDto dto = logic.Delete(id);
                    return Ok(dto);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        public void InjectLogic(WishLogic logic)
        {
            this.logic = logic;
        }
    }
}
