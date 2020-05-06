using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.Controllers.Thing;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Data.Household;
using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Data.Wish;
using ThingsWeNeed.Service.Controllers.Wish;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.UnitTests
{
    public static class TestData
    {
        public static readonly ThingDto TestThing1 = new ThingDto
        {
            DefaultPrice = 10,
            Needed = true,
            Name = "TestThing1",
            Show = true,
            HouseholdId = 1,
            ThingId = 1
        };

        public static readonly ThingDto TestThing2 = new ThingDto
        {
            DefaultPrice = 99,
            Needed = false,
            Name = "TestThing",
            Show = false,
            HouseholdId = 96,
            ThingId = 2
        };

        public static readonly WishDto TestWish1 = new WishDto
        {
            MaxPrice = 99,
            ExtraPay = 1,
            GrantedOn = DateTime.Today,
            WishId = 1,
            UserId = 1,
            Name = "noose"     
        };

        public static readonly HouseholdDto TestHousehold1 = new HouseholdDto
        {
            Address = new AddressDto() {
                Address1 = "Rostrupsvej 7, 2",
                City = "Aalborg",
                Country = "DK",
                PostCode = "9000"
            },
            HouseholdId = 1,
            Name = "TestHouse"
        };

        public static WishApiController GetInjecteddController()
        {
            WishApiController controller = new WishApiController();
            controller.InjectLogic(GetMockeddLogic());
            return controller;
        }

        public static WishLogic GetMockeddLogic()
        {
            TwnContext context = new TwnContext();

            WishLogic logic = new WishLogic();
            logic.InjectDatabaseContext(context);
            return logic;
        }

            public static ThingsApiController GetInjectedController()
        {
            ThingsApiController controller = new ThingsApiController();
            return controller;
        }

        //public static ThingDaLogic GetMockedLogic()
        //{
        //    TwnContext context = new TwnContext();
        //    ThingDaLogic logic = new ThingDaLogic(context, -1);
        //    return logic;
        //}
    }
}
