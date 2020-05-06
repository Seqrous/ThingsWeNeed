using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingsWeNeed.Shared.REST
{
    public class HouseholdRest : RestClient, IRestfulInterface<HouseholdDto>
    {
        public HouseholdRest() : base()
        {
            base.RouteString = "api/Households";
        }

        public HouseholdDto Create(HouseholdDto toCreate)
        {
            throw new NotImplementedException();
        }

        public HouseholdDto Delete(int id)
        {
            throw new NotImplementedException();
        }

        public HouseholdDto Get(int id)
        {
            return new HouseholdDto()
            {
                HouseholdId = id,
                Address = new AddressDto()
                {
                    Address1 = "Rostrupsvej 7, 2",
                    Address2 = "I dont know what this is used for tbh",
                    PostCode = "9000",
                    City = "Aalborg",
                    Country = "DK"
                },
                Name = "Crackhouse"
            };
        }

        public ICollection<HouseholdDto> GetCollection()
        {
            throw new NotImplementedException();
        }

        public HouseholdDto Update(HouseholdDto updated)
        {
            throw new NotImplementedException();
        }
    }
}
