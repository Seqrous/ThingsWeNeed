﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Shared;
using ThingsWeNeed.Service.Controllers.Thing;

using Moq;
using ThingsWeNeed.Controllers.Thing;
using System.Web.Http.Results;

using ThingsWeNeed.UnitTests;
using System.Web.Http;
using System.Diagnostics;
using ThingsWeNeed.Data.Household;

namespace ThingsWeNeed.UnitTests.Thing
{
    [TestClass]
    public class ThingsControllerTests
    {
        [TestMethod]
        public void Get_Ok() {

            //  Arrange
            var thing = getTestThing();
            int id = thing.ThingId;
            var controller = TestData.GetInjectedController();

            //  Act
            var result = (OkNegotiatedContentResult<ThingDto>) controller.Get(thing.ThingId);

            //  Assert
            Assert.IsTrue(result.Content.DefaultPrice == thing.DefaultPrice);

            //  Cleanup
            cleanup(thing.ThingId);
        }

        [TestMethod]
        public void GetCollection_Ok()
        {
            //  Arrange
            var thing1 = getTestThing();
            var thing2 = getTestThing();
            var controller = TestData.GetInjectedController();

            //  Act
            var result = (OkNegotiatedContentResult<ICollection<ThingDto>>)controller.GetCollection();

            //  Assert
            bool found1 = false;
            bool found2 = false;
            foreach (var t in result.Content) {
                if (t.ThingId == thing1.ThingId)
                {
                    found1 = true;
                }
                else if (t.ThingId == thing2.ThingId) {
                    found2 = true;
                }
            }

            Assert.IsTrue(found1);
            Assert.IsTrue(found2);

            //  Cleanup
            cleanup(thing1.ThingId);
            cleanup(thing2.ThingId);
        }

        [TestMethod]
        public void Create_Ok() {

            //  Arrange
            int id;
            int price = new Random().Next(1000);
            var dto = TestData.TestThing2;

            //  Act
            using (var controller = TestData.GetInjectedController())
            {
                dto.DefaultPrice = price;

                var result = (OkNegotiatedContentResult<ThingDto>) controller.Create(TestData.TestThing2);
                id = result.Content.ThingId;
            }

            //  Assert
            using (var context = new TwnContext())
            {
                Assert.IsTrue(context.Things.Find(id).DefaultPrice == price);
            }
            //  Cleanup
            cleanup(id);

        }

        [TestMethod]
        public void Update_Ok()
        {
            //  Arrange
            var thing = getTestThing();
            int id = thing.ThingId;
            OkNegotiatedContentResult<ThingDto> result; 

            //  Act
            using (var controller = TestData.GetInjectedController())
            {
                result = (OkNegotiatedContentResult<ThingDto>)controller.Update(id, TestData.TestThing2);
            }

            //  Assert
            Assert.IsTrue(result.Content.DefaultPrice == thing.DefaultPrice);

            //  Cleanup
            cleanup(thing.ThingId);

        }

        [TestMethod]
        public void Delete_Ok()
        {
            //  Arrange
            var thing = getTestThing();
            int id = thing.ThingId;
            var controller = TestData.GetInjectedController();

            //  Act
            var result = (OkNegotiatedContentResult<ThingDto>)controller.Delete(id);

            //  Assert
            Assert.IsTrue(result.Content.DefaultPrice == thing.DefaultPrice);

            //  Cleanup
            cleanup(id);
        }




        public ThingEntity getTestThing() {
            TwnContext context = new TwnContext();

            var household = context.Households.Add(new HouseholdEntity() {
                Address = new AddressDto() {
                    Address1 = "TestStreet 1",
                    City = "TestCity",
                    Country = "DK",
                    PostCode = "9000"
                },
                Name = "TestNameHousehold"
            });

            double price = new Random().Next(0, 1000);
            var thing = new ThingEntity() {
                Needed = true,
                Name = "TestThing",
                Household = household,
                DefaultPrice = price
            };
            var thingEntity = context.Things.Add(thing);
            context.Households.Add(household);
            using (context)
            {
                context.SaveChanges();
            }
            return thingEntity;
        }



        private void cleanup(int id) {
            ThingEntity thing;
            using (TwnContext context = new TwnContext())
            {
                thing = context.Things.Find(id);
                context.Things.Remove(thing);
                context.Households.Remove(context.Households.Find(thing.HouseholdId));
                context.SaveChanges();
            }
        }
    }

   
}
