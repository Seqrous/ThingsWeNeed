using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
            using (var client = CreateWebClient())
            {
                string returnString = client.UploadString(Uri, JsonConvert.SerializeObject(toCreate));
                HouseholdDto dto = (HouseholdDto)JsonConvert.DeserializeObject(returnString, typeof(HouseholdDto));

                return dto;
            }
        }

        public HouseholdDto Delete(int id)
        {
            using (var client = CreateWebClient())
            {
                string returnString = client.UploadString(Uri + $"/{id}", "DELETE", "");
                HouseholdDto dto = (HouseholdDto)JsonConvert.DeserializeObject(returnString, typeof(HouseholdDto));

                return dto;
            }
        }

        public HouseholdDto Get(int id)
        {
            using (var client = CreateWebClient())
            {
                string returnString = client.DownloadString(Uri + $"/{id}");
                HouseholdDto dto = (HouseholdDto)JsonConvert.DeserializeObject(returnString, typeof(HouseholdDto));
                return dto;
            }
        }

        public ICollection<HouseholdDto> GetCollection()
        {
            using (var client = CreateWebClient())
            {
                string returnString = client.DownloadString(Uri);
                ICollection<HouseholdDto> dtos = (ICollection<HouseholdDto>)JsonConvert.DeserializeObject(returnString, typeof(ICollection<HouseholdDto>));
                return dtos;
            }
        }

        public HouseholdDto Update(HouseholdDto updated)
        {
            throw new NotImplementedException();
        }
    }
}
