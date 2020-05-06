using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Data.Household;
using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Data.User;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Data.Thing
{
    public class ThingDaLogic : IRestResource<ThingDto>, IDisposable 
    {
        private string userId;
        private TwnContext context;

        public ThingDaLogic(TwnContext context, string userId)
        {
            this.context = context;
            this.userId = userId;
        }

        /// <summary>
        /// Get thing DTO by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Thing Data Transfer Object</returns>
        /// <exception cref="KeyNotFoundException">Datbase entry not found</exception>
        public ThingDto GetById(int id)
        {
            ThingEntity entity = context.Things.Find(id);

            if (entity != null)
            {
                ThingDto dto = new ThingDto()
                {
                    ThingId = entity.ThingId,
                    DefaultPrice = entity.DefaultPrice,
                    Name = entity.Name,
                    Needed = entity.Needed,
                    Show = entity.Show,
                    HouseholdId = entity.HouseholdId
                };
                return dto;
            }
            else
            {
                //  Use Key not found Exception for when a resource is not found
                throw new KeyNotFoundException();
            }
        }

        public ThingDto[] GetCollection()
        {
            ICollection<ThingDto> collection = new List<ThingDto>();

            var user = context.Users.Find(userId);

            foreach (HouseholdEntity household in user.Households)
            {
                foreach (var entity in household.Things)
                {
                    collection.Add(new ThingDto()
                    {
                        ThingId = entity.ThingId,
                        DefaultPrice = entity.DefaultPrice,
                        Name = entity.Name,
                        Needed = entity.Needed,
                        Show = entity.Show,
                        HouseholdId = entity.HouseholdId
                    });
                }
            }

            return collection.ToArray();
        }

        public ThingDto Create(ThingDto dto)
        {
            ThingEntity entity = new ThingEntity();

            entity.Name = dto.Name;
            entity.HouseholdId = dto.HouseholdId;
            entity.Show = dto.Show;
            entity.Needed = dto.Needed;
            entity.DefaultPrice = dto.DefaultPrice;

            context.Things.Add(entity);
            context.SaveChanges();

            return buildDto(entity);
        }

        public ThingDto[] UpdateCollectionNotNeeded(int[] idArray)
        {
            var entities = new List<ThingEntity>();
            foreach ( int id in idArray )
            {
                var entity = context.Things.Find(id);
                entity.Needed = false;
                entities.Add(entity);
            }
            context.SaveChanges();
            var retDtoCol = new List<ThingDto>();

            entities.ForEach(x => retDtoCol.Add(buildDto(x)));
            return retDtoCol.ToArray();
        }


        public ThingDto Update(ThingDto dto)
        {
            ThingEntity entity = context.Things.Find(dto.ThingId);

            if (entity != null)
            {
                entity.Show = dto.Show;
                entity.Needed = dto.Needed;
                entity.Name = dto.Name;
                entity.DefaultPrice = dto.DefaultPrice;
                
                context.SaveChanges();

                return buildDto(entity);
            } 
            else
            {
                throw new KeyNotFoundException($"Thing with id [{dto.ThingId}] not found");
            }
            
        }

        public ThingDto Delete(int id)
        {
            ThingEntity entity = context.Things.Find(id);
            if (entity != null)
            {
                ThingEntity retEntity = context.Things.Remove(entity);

                context.SaveChanges();

                return buildDto(retEntity);
            }
            else
            {
                throw (new KeyNotFoundException());
            }
        }

        private ThingDto buildDto(ThingEntity entity) {
            ThingDto dto = new ThingDto();
            dto.DefaultPrice = entity.DefaultPrice;
            dto.Name = entity.Name;
            dto.Show = entity.Show;
            dto.ThingId = entity.ThingId;
            dto.Needed = entity.Needed;
            dto.HouseholdId = entity.HouseholdId;

            return dto;
        }

        public void Dispose() {
            context.Dispose();
        }

        //public void Injectcontext(TwnContext context) {
        //    context = context;
        //}
    }
}