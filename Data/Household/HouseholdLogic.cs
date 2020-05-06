using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Data.User;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Data.Household
{
    public class HouseholdLogic : IDisposable
    {
        public TwnContext DatabaseContext { get; private set; }
        public ThingDaLogic thingDaLogic;

        public HouseholdLogic(TwnContext context, string userId)
        {
            DatabaseContext = new TwnContext();
            thingDaLogic = new ThingDaLogic(context, userId);
        }

        public HouseholdDto GetById(int id)
        {
            HouseholdEntity entity = DatabaseContext.Households.Find(id);
            return buildDto(entity);
        }
        public HouseholdDto[] GetCollection(int userId)
        {
            // keep track which households the user belongs to
            ICollection<HouseholdEntity> entityHouseholds = DatabaseContext.Users.Find(userId).Households;

            // list of household dto
            ICollection<HouseholdDto> householdDtos = new List<HouseholdDto>(); 

            // create household Dto for every household id
            foreach(HouseholdEntity he in entityHouseholds)
            {
                householdDtos.Add(buildDto(he));
            }

            //return the colletion
            return householdDtos.ToArray();
        }
        public HouseholdDto Update(HouseholdEntity entity)
        {
            HouseholdEntity householdEntity = DatabaseContext.Households.Find(entity.HouseholdId);
            householdEntity.Name = entity.Name;
            householdEntity.Address.Address1 = entity.Address.Address1;
            householdEntity.Address.Address2 = entity.Address.Address2;
            householdEntity.Address.City = entity.Address.City;
            householdEntity.Address.PostCode = entity.Address.PostCode;
            householdEntity.Address.Country = entity.Address.Country;

            DatabaseContext.SaveChanges();

            HouseholdDto householdDto = buildDto(householdEntity);
            return householdDto;
        }

        public bool Delete(int id)
        {
            HouseholdEntity householdEntity = DatabaseContext.Households.Find(id);
            HouseholdEntity householdRemoved = DatabaseContext.Households.Remove(householdEntity);
            return householdRemoved.HouseholdId == id ? true : false;
        }

        public HouseholdDto Create(HouseholdEntity newHousehold)
        {
            HouseholdEntity householdEntity = DatabaseContext.Households.Add(newHousehold);
            DatabaseContext.SaveChanges();

            HouseholdDto householdDto = buildDto(householdEntity);

            return householdDto;
        }

        public HouseholdDto buildDto(HouseholdEntity entity)
        {
            if (entity != null)
            {
                HouseholdDto dto = new HouseholdDto()
                {
                    HouseholdId = entity.HouseholdId,
                    Name = entity.Name,
                    Address = new AddressDto()
                    {
                        Address1 = entity.Address.Address1,
                        Address2 = entity.Address.Address2,
                        City = entity.Address.City,
                        PostCode = entity.Address.PostCode,
                        Country = entity.Address.Country
                    },
                    Things = fillThingsCollection(),
                    Users = fillUserCollection()
                };
                return dto;
            }
            else
            {
                throw new KeyNotFoundException();
            }

            //  Wtf is this for?
            ICollection<UserDto> fillUserCollection()


            {
                var userEntities = DatabaseContext.Households.Find(entity.HouseholdId).Users;

                ICollection<ThingDto> usersDto = new List<ThingDto>();

                foreach (UserEntity ue in userEntities)
                {
                    if (ue != null)
                    {
                        //usersDto.Add(userLogic.GetById(ue.UserId));
                    }
                }
                return usersDto;
            }
            ICollection<ThingDto> fillThingsCollection()
            {
                // create the collection of DTO Users
                var entityThings = DatabaseContext.Households.Find(entity.HouseholdId).Things;
                ICollection<ThingDto> thingsDto = new List<ThingDto>();

                foreach (ThingEntity te in entityThings)
                {
                    if (te != null)
                    {
                        thingsDto.Add(thingDaLogic.GetById(te.ThingId));
                    }
                }
                return thingsDto;
            }
        }
        public void Dispose()
        {
            DatabaseContext.Dispose();
        }

        public void InjectDatabaseContext(TwnContext context)
        {
            DatabaseContext = context;
        }
    }

    
}
