using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ThingsWeNeed.Shared.REST;

namespace ThingsWeNeed.Shared.RestInterface.Rest
{
    public class UserRest : RestClient, IRestfulInterface<UserDto>
    {
        public UserRest() : base()
        {
            base.RouteString = "api/Users";
        }

        public UserDto Create(UserDto toCreate)
        {
            using (var client = CreateWebClient())
            {
                string returnString = client.UploadString(Uri, JsonConvert.SerializeObject(toCreate));
                UserDto dto = (UserDto)JsonConvert.DeserializeObject(returnString, typeof(UserDto));

                return dto;
            }
        }

        public UserDto Delete(int id)
        {
            using (var client = CreateWebClient())
            {
                string returnString = client.UploadString(Uri + $"/{id}", "DELETE", "");
                UserDto dto = (UserDto)JsonConvert.DeserializeObject(returnString, typeof(UserDto));

                return dto;
            }
        }

        public UserDto Get(int id)
        {
            using (var client = CreateWebClient())
            {
                string returnString = client.DownloadString(Uri + $"/{id}");
                UserDto dto = (UserDto)JsonConvert.DeserializeObject(returnString, typeof(UserDto));
                return dto;
            }
        }

        public ICollection<UserDto> GetCollection()
        {
            using (var client = CreateWebClient())
            {
                string returnString = client.DownloadString(Uri);
                ICollection<UserDto> dtos = (ICollection<UserDto>)JsonConvert.DeserializeObject(returnString, typeof(ICollection<UserDto>));
                return dtos;
            }
        }

        public UserDto Update(UserDto updated)
        {
            throw new NotImplementedException();
        }
    }
}
