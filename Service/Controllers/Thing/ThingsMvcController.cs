using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Service.ViewModels;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Service.Controllers.Thing
{
    [RoutePrefix("Things")]
    [Authorize]
    public class ThingsMvcController : Controller
    {
        [Route("all")]
        [Route("")]
        [HttpGet]
        public ActionResult All()
        {
            ThingDto[] thingArray;

            using (var logic = new ThingDaLogic(new TwnContext(), User.Identity.GetUserId()))
            {
                thingArray = logic.GetCollection();
            }

            ThingListViewModel viewModel = new ThingListViewModel() {
                Things = thingArray
            };

            return View("List", viewModel);

                //return View("Index", new MultiViewModel() {
                //    HouseholdList = new HouseholdListViewModel() {
                //        Households = new List<HouseholdDto>() {
                //        new HouseholdDto() {
                //            HouseholdId = 191919,
                //            Name = "Crackhoussse",
                //            Address = new AddressDto() {
                //                Address1 = "rostrupsvej 7",
                //                Address2 = "",
                //                City = "Aalborg",
                //                Country = "DK",
                //                PostCode = "9000"
                //            }
                //        }
                //    }
                //    }
                //});
        }

        //[Route("{id}")]
        //[HttpGet]
        //public ActionResult Details([Bind(Include = "id")] int id) {
        //    if (!ModelState.IsValid)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());
        //    }
        //    else
        //    {
        //        ThingDto thing;
        //        using (var db = new ThingDaLogic(null, null))
        //        {
        //            thing = db.GetById(id);
        //        }

        //        ThingDetailsViewModel viewModel = new ThingDetailsViewModel() {
        //            Thing = thing
        //        };

        //        return View("Details", viewModel);
        //    }
        //}

        [Route("create")]
        public ActionResult Create(ThingDto dto)
        {
            return View("Create");
        }

        [Route("{id}")]
        public ActionResult Update(int id)
        {
            ThingUpdateViewModel viewModel;

            using (var logic = new ThingDaLogic(new TwnContext(), User.Identity.GetUserId())) {
                viewModel = new ThingUpdateViewModel()
                {
                    Thing = logic.GetById(id)
                };
            };
        
            return View("Update", viewModel);
        }

        //public ActionResult Create([Bind(Include = "dto")] ThingDto dto) {
        //    if (!ModelState.IsValid)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());
        //    }
        //    else
        //    {
        //        ThingDto thing;
        //        using (var db = new ThingDaLogic(null, null))
        //        {
        //            //thing = db.Create(dto.Name, dto.HouseholdId, dto.Show, dto.Needed, dto.DefaultPrice);
        //        }

        //        ThingDetailsViewModel viewModel = new ThingDetailsViewModel()
        //        {
        //            Thing = null
        //        };

        //        return View("Details", viewModel);
        //    }
        //}

    }
}