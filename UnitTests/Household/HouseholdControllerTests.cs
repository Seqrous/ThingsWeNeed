using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Data.Household;
using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Data.User;
using ThingsWeNeed.Service.Controllers.Household;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.UnitTests.Household
{
    [TestClass]
    public class HouseholdControllerTest
    {
        [TestMethod]
        public void Get_Ok()
        {
            //Arrange 
            var householdList = addTestHousehold();
            var household = householdList.ElementAt(0);
            int householdId = household.HouseholdId;

            try
            {
                var controller = TestData.GetHouseholdController();

                //Act
                var result = (OkNegotiatedContentResult<HouseholdDto>)controller.Get(householdId);

                //Assert
                Assert.IsTrue(result.Content.HouseholdId == householdId);
            }
            finally
            {
                cleanup(householdList);
            }
        }

        [TestMethod]
        public void GetCollection_Ok()
        {
            // Arrange
            var householdList = addTestHousehold();
            int userId = 1;
            try
            {
                var controller = TestData.GetHouseholdController();

                // Act 
                var result = (OkNegotiatedContentResult<HouseholdDto[]>)controller.GetCollection(userId);

                // Assert
                Assert.IsTrue(result.Content.Length > 0 ? true : false);
            }
            finally
            {
                cleanup(householdList);
            }
        }

        [TestMethod]
        public void Put_Ok()
        {
            // Arrange 
            var householdList = addTestHousehold();
            // household to update
            var household = householdList.ElementAt(0);
            int householdId = household.HouseholdId;
            // household with updated data
            HouseholdEntity updatedHousehold = new HouseholdEntity();
            // data for update
            string newName = "UpdatedName";
            string newAddress1 = "UpdatedAddress1";
            string newAddress2 = "Updatedaddress2";
            string newCity = "UpdatedAalborg";
            string newPostCode = "Updated9000";
            string newCountry = "UpdatedDK";
            // preparing an updated entity
            updatedHousehold.HouseholdId = householdId;
            updatedHousehold.Name = newName;
            AddressDto addressDto = new AddressDto();
            addressDto.Address1 = newAddress1;
            addressDto.Address2 = newAddress2;
            addressDto.City = newCity;
            addressDto.PostCode = newPostCode;
            addressDto.Country = newCountry;
            updatedHousehold.Address = addressDto;

            try
            {
                var controller = TestData.GetHouseholdController();

                // Act 
                var result = (OkNegotiatedContentResult<HouseholdDto>)controller.Update(householdId, updatedHousehold);

                // Assert
                if (result.Content.Name.Equals(newName) && result.Content.Address.Address1.Equals(newAddress1) &&
                    result.Content.Address.Address2.Equals(newAddress2) && result.Content.Address.City.Equals(newCity) &&
                    result.Content.Address.PostCode.Equals(newPostCode) && result.Content.Address.Country.Equals(newCountry))
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.IsTrue(false);
                }
            }
            finally
            {
                cleanup(householdList);
            }

        }

        [TestMethod]
        public void Delete_Ok()
        {
            // Arrange
            var householdList = addTestHousehold();
            var household = householdList.ElementAt(0);
            int householdId = household.HouseholdId;

            try
            {
                var controller = TestData.GetHouseholdController();

                // Act
                var result = (OkNegotiatedContentResult<bool>)controller.Delete(householdId);

                // Assert
                Assert.IsTrue(result.Content);
            }
            finally
            {
                cleanup(householdList);
            }
        }

        [TestMethod]
        public void Create_Ok()
        {
            // Arrange
            string name = "CreateTest";
            string address1 = "address1CreateTest";
            string address2 = "address2CreateTest";
            string city = "CityCreateTest";
            string postCode = "PostCodeCreateTest";
            string country = "CountryCreateTest";
            // new entity to insert
            HouseholdEntity householdEntity = new HouseholdEntity();
            householdEntity.Name = name;
            householdEntity.Address = new AddressDto();
            householdEntity.Address.Address1 = address1;
            householdEntity.Address.Address2 = address2;
            householdEntity.Address.City = city;
            householdEntity.Address.PostCode = postCode;
            householdEntity.Address.Country = country;

            try
            {
                var controller = TestData.GetHouseholdController();

                // Act 
                var result = (OkNegotiatedContentResult<HouseholdDto>)controller.Create(householdEntity);

                // Assert
                if (result.Content.Name.Equals(name) && result.Content.Address.Address1.Equals(address1) &&
                    result.Content.Address.Address2.Equals(address2) && result.Content.Address.City.Equals(city) &&
                    result.Content.Address.PostCode.Equals(postCode) && result.Content.Address.Country.Equals(country))
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.IsTrue(false);
                }
            }
            finally
            {
            }
        }

        public ICollection<HouseholdEntity> addTestHousehold()
        {
            TwnContext context = new TwnContext();

            // add a hosuehold
            var household = context.Households.Add(new HouseholdEntity()
            {
                Address = new AddressDto()
                {
                    Address1 = "Rostrupsvej 15",
                    City = "Aalborg",
                    Country = "DK",
                    PostCode = "9000"
                },
                Name = "ShoulderShoulderShoulderShoulder"
            });

            var household1 = context.Households.Add(new HouseholdEntity()
            {
                Address = new AddressDto()
                {
                    Address1 = "Seklagervej 8",
                    City = "Aalborg",
                    Country = "DK",
                    PostCode = "9000"
                },
                Name = "UgandanCamp"
            });

            // add thing 1
            var thing1 = context.Things.Add(new ThingEntity()
            {                
                Needed = true,
                Name = "ToothpasteTest1",
                Household = household,
                DefaultPrice = 189
            });

            // add thing 2
            var thing2 = context.Things.Add(new ThingEntity()
            {
                Needed = true,
                Name = "BreadcrumbsTest2",
                Household = household,
                DefaultPrice = 20
            });

            //  add things to the lsit
            var thingList = new List<ThingEntity>();
            thingList.Add(thing1);
            thingList.Add(thing2);

            // add household to the set
            var hashSet = new HashSet<HouseholdEntity>();
            hashSet.Add(household);
            
            // add a user1
            var user1 = context.Users.Add(new UserEntity()
            {
                Email = "user1@gmail.com",
                Username = "UserThe1",
                PenisSize = 10.0f,
                FName = "Us",
                LName = "Er",
                PhoneNumber = "0987654321",
                Households = hashSet
            });
            
            // add a user2
            var user2 = context.Users.Add(new UserEntity()
            {
                Email = "user2@gmail.com",
                Username = "UserThe2",
                PenisSize = 20.0f,
                FName = "Us",
                LName = "Er",
                PhoneNumber = "1234567890",
                Households = hashSet
            });

            // add users to the list
            var userList = new List<UserEntity>();
            userList.Add(user1);
            userList.Add(user2);

            // update user and thing in household
            household.Users = userList;
            household.Things = thingList;

            using (context)
            {
                context.SaveChanges();
            }
            // list of households to return 
            var householdList = new List<HouseholdEntity>();
            householdList.Add(household);
            householdList.Add(household1);
            return householdList;
        }

        private void cleanup(ICollection<HouseholdEntity> householdList)
        {
            using (TwnContext context = new TwnContext())
            {
                foreach (HouseholdEntity household in householdList.ToList())
                {
                
                    foreach (ThingEntity te in household.Things.ToList())
                    {
                        if(context.Things != null)
                        {
                            try
                            {
                                context.Things.Remove(te);
                            }
                            catch(System.InvalidOperationException e)
                            {
                                // do nothing
                            }
                        }
                    }

                    foreach (UserEntity ue in household.Users.ToList())
                    {
                        if(context.Users != null)
                        {
                            try
                            {
                                context.Users.Remove(ue);
                            }
                            catch(System.InvalidOperationException e)
                            {
                                // do nothing
                            }
                        }
                    }

                    try
                    {
                        context.Households.Remove(household);
                    }
                    catch(System.InvalidOperationException e)
                    {
                        // do nothing
                    }
                    
                }
                context.SaveChanges();
            }
        }
    }
 
}
