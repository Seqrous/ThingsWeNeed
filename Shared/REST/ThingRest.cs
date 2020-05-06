using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public ThingDto Update(ThingDto updated)
        {
            throw new NotImplementedException();
        }
    }
}
