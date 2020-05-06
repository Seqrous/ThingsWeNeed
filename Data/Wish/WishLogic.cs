using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Data.User;
using ThingsWeNeed.Data.Wish;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Data.Wish
{
    public class WishLogic : IDisposable
    {
        public TwnContext DatabaseContext { get; private set; }

        public WishLogic()
        {
            DatabaseContext = new TwnContext();
        }
        public WishDto GetById(int id)
        {
            var entity = DatabaseContext.Wishes.Find(id);

            if (entity != null)
            {
                WishDto dto = new WishDto()
                {
                    WishId = entity.WishId,
                    Name = entity.Name,
                    MaxPrice = entity.MaxPrice,
                    ExtraPay = entity.ExtraPay,
                    Show = entity.Show,

                    MadeById = entity.MadeById,
                    MadeOn = entity.MadeOn,

                    GrantedById = entity.GrantedById,
                    GrantedOn = entity.GrantedOn,
                };
                return dto;
            }
            else
            {
                //  Use Key not found Exception for when a resource is not found
                throw new KeyNotFoundException();


            }
           
        }

        public WishDto[] GetCollection()
        {
            List<WishEntity> wishesList = DatabaseContext.Wishes.ToList();
            List<WishDto> wishDtoList = new List<WishDto>();

            foreach (WishEntity entity in wishesList)
            {
                if (entity != null)
                {
                    WishDto dto = new WishDto()
                    {
                        WishId = entity.WishId,
                        Name = entity.Name,
                        MaxPrice = entity.MaxPrice,
                        ExtraPay = entity.ExtraPay,
                        Show = entity.Show,

                        MadeById = entity.MadeById,
                        MadeOn = entity.MadeOn,

                        GrantedById = entity.GrantedById,
                        GrantedOn = entity.GrantedOn,
                    };
                    wishDtoList.Add(dto);
                }
            }
            return wishDtoList.ToArray();
        }

        public WishDto[] GetCollectionByUserId(string userId)
        {
            WishDto[] result;


            UserEntity user = DatabaseContext.Users.Find(userId);
            if (user != null)
            {
                List<WishDto> list = new List<WishDto>();
                foreach (var entity in user.MadeWishes)
                {
                    WishDto dto = new WishDto()
                    {
                        WishId = entity.WishId,
                        Name = entity.Name,
                        MaxPrice = entity.MaxPrice,
                        ExtraPay = entity.ExtraPay,
                        Show = entity.Show,

                        MadeById = entity.MadeById,
                        MadeOn = entity.MadeOn,

                        GrantedById = entity.GrantedById,
                        GrantedOn = entity.GrantedOn,
                    };
                }
                result = list.ToArray();
            }
            else
            {
                throw new KeyNotFoundException("Requested user not found");
            }

            return result;
        }

        public WishDto Update(int id)
        {
            WishEntity entity = DatabaseContext.Wishes.Find(id);

            if (entity != null)
            {
                DatabaseContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;

                WishDto dto = new WishDto()
                {
                    WishId = entity.WishId,
                    //UserId = entity.UserId,
                    ExtraPay = entity.ExtraPay,
                    MaxPrice = entity.MaxPrice,
                    GrantedOn = entity.GrantedOn,
                    Name = entity.Name
                };

                DatabaseContext.SaveChanges();

                return dto;


            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void Create(WishDto dto)
        {
            WishEntity entity = new WishEntity()
            {
                ExtraPay = dto.ExtraPay,
                MadeOn = (DateTime) dto.MadeOn,
                MadeById = dto.MadeById,
                GrantedById = dto.GrantedById,
                GrantedOn = dto.GrantedOn,
                Name = dto.Name,
                MaxPrice = dto.MaxPrice
            };

            DatabaseContext.Wishes.Add(entity);

            DatabaseContext.SaveChanges();

            dto.WishId = entity.WishId;

        }

        public WishDto Delete(int id)
        {
            var entity = DatabaseContext.Wishes.Find(id);
            if (entity != null)
            {
                entity.Show = false;

                WishDto dto = new WishDto()
                {
                    WishId = entity.WishId,
                    Name = entity.Name,
                    MaxPrice = entity.MaxPrice,
                    ExtraPay = entity.ExtraPay,
                    Show = entity.Show,

                    MadeById = entity.MadeById,
                    MadeOn = entity.MadeOn,

                    GrantedById = entity.GrantedById,
                    GrantedOn = entity.GrantedOn,
                };

                DatabaseContext.SaveChanges();

                return dto;
            }
            else
            {
                throw (new KeyNotFoundException());
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

