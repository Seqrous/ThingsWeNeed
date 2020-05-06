using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThingsWeNeed.Data.Household;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Service.ViewModels;
using ThingsWeNeed.Shared;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;

namespace ThingsWeNeed.Service.Controllers.Household
{
    [Authorize]
    [RoutePrefix("Households")]
    public class HouseholdsMvcController : Controller
    {

        [Route("")]
        public ActionResult List() 
        {
            HouseholdDaLogic data = new HouseholdDaLogic(new TwnContext(), User.Identity.GetUserId());

            HouseholdListViewModel viewModel = new HouseholdListViewModel() {
                Households = data.GetCollection().ToList()
            };

            return View("List", viewModel);
        }

        [Route("{id}")]
        public ActionResult Update(int id)
        {
            HouseholdDaLogic data = new HouseholdDaLogic(new TwnContext(), User.Identity.GetUserId());

            HouseholdUpdateViewModel viewModel = new HouseholdUpdateViewModel() {
                Household = data.GetById(id)
            };

            return View("Update", viewModel);
        }

        [Route("create")]
        public ActionResult Create()
        {
            HouseholdCreateViewModel viewModel = new HouseholdCreateViewModel();

            return View("Create", viewModel);
        }
    }
}