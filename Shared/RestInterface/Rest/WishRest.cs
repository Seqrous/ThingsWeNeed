using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingsWeNeed.Shared.REST
{
    public class WishRest : RestClient, IRestfulInterface<WishDto>
    {
        public WishRest() : base()
        {
            base.RouteString = "api/Wishes";
        }

        public WishDto Create(WishDto toCreate)
        {
            throw new NotImplementedException();
        }

        public WishDto Delete(int id)
        {
            throw new NotImplementedException();
        }

        public WishDto Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<WishDto> GetCollection()
        {
            throw new NotImplementedException();
        }

        public WishDto Update(WishDto updated)
        {
            throw new NotImplementedException();
        }
    }
}
