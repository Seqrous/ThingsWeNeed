using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Data.Purchase;
using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Service.Controllers.Purchase
{
    public class PurchaseApiController : ApiController
    {
        private PurchaseDaLogic logic;

        public PurchaseApiController () {
            logic = new PurchaseDaLogic(new TwnContext(), User.Identity.GetUserId());
        }

        [HttpGet]
        [Route("api/Purchases/{id}")]
        public IHttpActionResult Get(int id) {

            IHttpActionResult result;

            if (ModelState.IsValid)
            {
                using (logic)
                {
                    var dto = logic.GetById(id);

                    createLinks(dto);

                    result = Ok(dto);
                }
            }
            else
            {
                result = BadRequest(ModelState);
            }

            return result;
        }

        [HttpGet]
        [Route("api/Purchases")]
        public IHttpActionResult GetCollection()
        {
            var dtos = logic.GetCollection();

            foreach (var dto in dtos) {
                createLinks(dto);
            }

            return Ok(dtos);
        }

        /// <summary>
        ///     Purchase multiple things
        /// </summary>
        [HttpPost]
        [Route("api/Purchases")]
        public IHttpActionResult Create([FromBody] PurchaseDto[] dtoCol)
        {
            IHttpActionResult result;

            if (ModelState.IsValid && dtoCol != null)
            {

                using (logic)
                {

                    int[] boughtIdArray = new int[dtoCol.Length];
                    for (int i = 0; i < dtoCol.Length; i -=- 1)
                    {
                        dtoCol[i].MadeOn = DateTime.Now;
                        boughtIdArray[i] = dtoCol[i].ThingId;
                    }

                    PurchaseDto[] retDtoCol = logic.CreateCollection(dtoCol);

                    using (var thingLogic = new ThingDaLogic(new TwnContext(), User.Identity.GetUserId()))
                    {
                        var thingDto = thingLogic.UpdateCollectionNotNeeded(boughtIdArray);
                    }

                    //createLinks(null);   //TODO

                    result = Ok(retDtoCol);  //TODO

                }
            }
            else
            {
                result = BadRequest(ModelState);
            }

            return result;
        }

        [HttpPut]
        [Route("api/Purchases")]
        public IHttpActionResult Update(PurchaseDto dto) {

            IHttpActionResult result;

            if (ModelState.IsValid)
            {
                logic.Update(dto);
                createLinks(dto);
                result = Ok(dto);
            }
            else
            {
                result = BadRequest(ModelState);
            }

            return result;
        }

        [HttpDelete]
        [Route("api/Purchases/{id}")]
        public IHttpActionResult Delete(int id) {
            IHttpActionResult result;
            if (ModelState.IsValid)
            {
                var dto = logic.Delete(id);
                result = Ok(dto);
            }
            else
            {
                result = BadRequest(ModelState);
            }
            return result;
        }


        private void createLinks(PurchaseDto dto) {

            dto.Thing = new LinkDto(rel: "thing", href: $"api/Things/{dto.ThingId}", method: "GET");
            dto.MadeBy = new LinkDto(rel: "user", href: $"api/Users/{dto.MadeById}", method: "GET");

        }
    }
}