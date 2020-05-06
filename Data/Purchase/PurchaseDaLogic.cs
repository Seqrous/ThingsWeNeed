using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Data.User;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Data.Purchase
{
    public class PurchaseDaLogic : IRestResource<PurchaseDto>, IDisposable
    {
        private string userId;
        private TwnContext context;

        public PurchaseDaLogic(TwnContext context, string userId)
        {
            this.context = context;
            this.userId = userId;
        }

        public PurchaseDto GetById(int id) {

            var entity = context.Purchases.Find(id);

            if (entity != null)
            {
                var dto = toDto(entity);

                return dto;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public PurchaseDto[] GetCollection() {

            var entities = context.Purchases.ToArray();

            PurchaseDto[] dtos = entities.Select(x => toDto(x)).ToArray();

            return dtos;
        }

        public PurchaseDto Create(PurchaseDto dto) {
            var entity = new PurchaseEntity()
            {
                ThingId = dto.ThingId,
                MadeById = dto.MadeById,
                Price = dto.Price,
                MadeOn = dto.MadeOn,
            };

            context.Purchases.Add(entity);
            context.SaveChanges();

            dto.PurchaseId = entity.PurchaseId;

            throw new NotImplementedException();
        }

        public PurchaseDto[] CreateCollection(PurchaseDto[] dtoCol)
        {
            PurchaseEntity[] entityArray = new PurchaseEntity[dtoCol.Length];

            for (int i = 0; i < dtoCol.Length; i++)
            {
                var entity = new PurchaseEntity
                {
                    MadeById = userId,
                    MadeOn = dtoCol[i].MadeOn,
                    Price = dtoCol[i].Price,
                    ThingId = dtoCol[i].ThingId,
                };

                context.Purchases.Add(entity);
                entityArray[i] = entity;
            }
            context.SaveChanges();

            PurchaseDto[] retDtoCol = new PurchaseDto[entityArray.Length];

            for (int i = 0; i < entityArray.Length; i++)
            {
                retDtoCol[i] = toDto(entityArray[i]);
            }

            return retDtoCol;
        }

        public PurchaseDto Update(PurchaseDto dto) {

            var entity = context.Purchases.Find(dto.ThingId);

            if (entity != null)
            {
                entity.Price = dto.Price;
                context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException();
            }

            throw new NotImplementedException();

        }



        public PurchaseDto Delete(int id) {
            var entity = context.Purchases.Find(id);

            if (entity != null)
            {
                context.Purchases.Remove(entity);
                context.SaveChanges();
                return(toDto(entity));
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public void Dispose() {
            context.Dispose();
        }

        private PurchaseDto toDto (PurchaseEntity entity)
        {
            return new PurchaseDto 
            { 
                MadeById = entity.MadeById,
                Price = entity.Price,
                ThingId = entity.ThingId,
                MadeOn = entity.MadeOn,
                PurchaseId = entity.PurchaseId
            };
        }
    }
}
