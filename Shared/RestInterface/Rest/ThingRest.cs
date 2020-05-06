using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ThingsWeNeed.Shared.REST
{
    public class ThingRest : RestClient, IRestfulInterface<ThingDto>
    {
        public ThingRest() : base()
        {
            base.RouteString = "api/Things";
        }

        public ThingDto Create(ThingDto toCreate)
        {
            using (var client = CreateWebClient())
            {
                string returnString = client.UploadString(Uri, JsonConvert.SerializeObject(toCreate));
                ThingDto dto = (ThingDto)JsonConvert.DeserializeObject(returnString, typeof(ThingDto));

                return dto;
            }
        }

        public ThingDto Delete(int id)
        {
            using (var client = CreateWebClient())
            {
                string returnString = client.UploadString(Uri + $"/{id}", "DELETE", "");
                ThingDto dto = (ThingDto)JsonConvert.DeserializeObject(returnString, typeof(ThingDto));

                return dto;
            }
        }

        public ThingDto Get(int id)
        {
            using (var client = CreateWebClient())
            {
                string returnString = client.DownloadString(Uri + $"/{id}");
                ThingDto dto = (ThingDto)JsonConvert.DeserializeObject(returnString, typeof(ThingDto));
                return dto;
            }
        }

        public ICollection<ThingDto> GetCollection()
        {
            using (var client = CreateWebClient())
            {
                string returnString = client.DownloadString(Uri);
                ICollection<ThingDto> dtos = (ICollection<ThingDto>)JsonConvert.DeserializeObject(returnString, typeof(ICollection<ThingDto>));
                return dtos;
            }
        }

        public ThingDto Update(ThingDto updated)
        {
            throw new NotImplementedException();
        }
    }
}
