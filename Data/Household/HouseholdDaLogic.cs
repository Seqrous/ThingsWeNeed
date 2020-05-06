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
    public class HouseholdDaLogic : IRestResource<HouseholdDto>, IDisposable
    {
        public TwnContext DatabaseContext { get; private set; }
        public ThingDaLogic thingDaLogic;
        private string userId;

        public HouseholdDaLogic(TwnContext context, string userId)
        {
            this.userId = userId;
            DatabaseContext = new TwnContext();
            thingDaLogic = new ThingDaLogic(context, userId);
        }

        public HouseholdDto GetById(int id)
        {
            HouseholdEntity entity = DatabaseContext.Households.Find(id);

            if (entity == null)
                throw new KeyNotFoundException($"Household with id [{id}] not found");

            return buildDto(entity);
        }


        public HouseholdDto[] GetCollection()
        {
            //// keep track which households the user belongs to
            //ICollection<HouseholdEntity> entityHouseholds = DatabaseContext.Users.Find(userId).Households;

            //// list of household dto
            //ICollection<HouseholdDto> householdDtos = new List<HouseholdDto>();

            //// create household Dto for every household id
            //foreach (HouseholdEntity he in entityHouseholds)
            //{
            //    householdDtos.Add(buildDto(he));
            //}

            ////return the colletion
            //return householdDtos.ToArray();

            var user = DatabaseContext.Users.Find(userId);

            if (user == null)
                throw new KeyNotFoundException("User not found");

            var householdList = new List<HouseholdDto>();
            foreach (var household in user.Households)
            {
                householdList.Add(buildDto(household));
            }
            
            return householdList.ToArray();

            //throw new NotImplementedException();
        }


        public HouseholdDto Update(HouseholdDto dto)
        {
            HouseholdEntity householdEntity = DatabaseContext.Households.Find(dto.HouseholdId);

            if (householdEntity == null)
                throw new KeyNotFoundException($"Household with id [{dto.HouseholdId}] not found");

            householdEntity.Name = dto.Name;
            householdEntity.Address = dto.Address;

            DatabaseContext.SaveChanges();

            HouseholdDto householdDto = buildDto(householdEntity);
            return householdDto;
        }

        public HouseholdDto Delete(int id)
        {
            HouseholdEntity householdEntity = DatabaseContext.Households.Find(id);

            if (householdEntity == null)
                throw new KeyNotFoundException($"Household with id [{id}] not found");

            HouseholdEntity householdRemoved = DatabaseContext.Households.Remove(householdEntity);
            
            return buildDto(householdRemoved);
        }


        public HouseholdDto Create(HouseholdDto newHousehold)
        {
            HouseholdEntity entity = new HouseholdEntity() {
                Address = newHousehold.Address,
                Name = newHousehold.Name,
            };

            DatabaseContext.Households.Add(entity);
            DatabaseContext.SaveChanges();
            
            return buildDto(entity);
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
                    //Users = fillUserCollection()
                };
                return dto;
            }
            else
            {
                throw new KeyNotFoundException();
            }

            /*
            //  Wtf is this for?
            ICollection<UserDto> fillUserCollection()
            {
                var userEntities = DatabaseContext.Households.Find(entity.HouseholdId).Users;

                ICollection<UserDto> usersDto = new List<UserDto>();

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
            */
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

