using System ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Shared;

using Moq;
using System.Data.Entity;
using ThingsWeNeed.Data.User;
using ThingsWeNeed.Data.Household;

using ThingsWeNeed.UnitTests;

namespace ThingsWeNeed.UnitTests.Thing
{
    [TestClass]
    public class ThingsDataAccessTests
    {
        [TestMethod]
        public void Get_Ok()
        {
            //  Arrange
            var logic = Mocks.GetMockedLogic();

            //  Act
            ThingDto dto = logic.GetById(1);

            //  Assert
            Assert.IsTrue(
                dto.DefaultPrice == Mocks.TestThing1.DefaultPrice &&
                dto.ThingId == Mocks.TestThing1.ThingId &&
                dto.Show == Mocks.TestThing1.Show &&
                dto.Needed == Mocks.TestThing1.Needed &&
                dto.Name == Mocks.TestThing1.Name &&
                dto.HouseholdId == Mocks.TestThing1.HouseholdId &&
                dto.Household.GetType() == typeof(LinkDto));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]   //  Assert
        public void Get_0_KeyNotFoundException()
        {
            //  Arrange
            var logic = Mocks.GetMockedLogic();

            //  Act
            logic.GetById(0);

        }

        [TestMethod]
        public void GetCollection()
        {
            //  Arrange
            var logic = Mocks.GetMockedLogic();

            //  Act
            var things = logic.GetCollection();


            //  Assert
            foreach (ThingDto thing in things)
            {
                Assert.IsTrue(
                    thing.Links.Count > 1 &&
                    thing.Household.getType() == typeof(ThingDto)
                );
            }
        }

        [TestMethod]
        public void Create()
        {
            //  Arrange
            var logic = Mocks.GetMockedLogic();
            var testThing = Mocks.TestThing2;

            //  Act
            ThingDto dto = logic.Create(
                name: testThing.Name, 
                householdId: testThing.HouseholdId, 
                show: testThing.Show, 
                needed: testThing.Needed, 
                defaultPrice: testThing.DefaultPrice);

            //  Assert
            var createdThing = logic.DatabaseContext.Things.Find(dto.ThingId);
            Assert.IsTrue(
                createdThing.ThingId != 0 &&
                createdThing.Show == testThing.Show &&
                createdThing.Needed == testThing.Needed &&
                createdThing.Name == testThing.Name &&
                createdThing.HouseholdId == testThing.HouseholdId &&
                createdThing.DefaultPrice == testThing.DefaultPrice);
        }

        [TestMethod]
        public void Update()
        {
            //  Arrange
            var logic = Mocks.GetMockedLogic();
            var testThing = Mocks.TestThing2;

            //  Act
            ThingDto dto = logic.Create(
                name: testThing.Name,
                householdId: testThing.HouseholdId,
                show: testThing.Show,
                needed: testThing.Needed,
                defaultPrice: testThing.DefaultPrice);

            //  Assert
            var updatedThing = logic.DatabaseContext.Things.Find(dto.ThingId);
            Assert.IsTrue(
                updatedThing.ThingId == 1 &&
                updatedThing.Show == testThing.Show &&
                updatedThing.Needed == testThing.Needed &&
                updatedThing.Name == testThing.Name &&
                updatedThing.HouseholdId == testThing.HouseholdId &&
                updatedThing.DefaultPrice == testThing.DefaultPrice);
        }

        [TestMethod]
        public void Delete()
        {
            //  Arrange
            var logic = Mocks.GetMockedLogic();

            //  Act
            logic.DatabaseContext.Things.Remove(logic.DatabaseContext.Things.Find(1));
            logic.DatabaseContext.SaveChanges();

            //  Assert
            Assert.IsNull(logic.DatabaseContext.Things.Find(1));
        }
    }
}
