using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingsWeNeed.Shared.REST
{
    public class PurchaseRest : RestClient, IRestfulInterface<PurchaseDto>
    {
        public PurchaseRest() : base ()
        {
            base.RouteString = "api/Purchases";
        }

        public PurchaseDto Create(PurchaseDto toCreate)
        {
            throw new NotImplementedException();
        }

        public PurchaseDto Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PurchaseDto Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PurchaseDto> GetCollection()
        {
            throw new NotImplementedException();
        }

        public PurchaseDto Update(PurchaseDto updated)
        {
            throw new NotImplementedException();
        }
    }
}
