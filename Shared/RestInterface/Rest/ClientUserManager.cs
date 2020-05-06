using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.IO;

namespace ThingsWeNeed.Shared.REST
{
    public class ClientUserManager : RestClient
    {
        public ClientUserManager() : base()
        {
            base.RouteString = "api/Users";
        }

        /// <summary>
        ///     Login user with username and password
        /// </summary>
        /// <returns>Error strings, null if OK</returns>
        public string[] Login(LoginBinder binder)
        {
            string[] result;

            using (var client = CreateWebClient())
            {
                try
                {
                    client.UploadString(Uri + "/Login", JsonConvert.SerializeObject(binder));

                    HandleCookies(client.ResponseHeaders);

                    result = null;
                }
                catch (WebException e)
                {
                    ErrorResponse errResp = ErrorResponse.Handle(e);
                    if (errResp != null)
                    {
                        result = errResp.Errors.ToArray();
                    }
                    else
                    {
                        result = new string[] { "Login failed" };
                    }
                }
            }
            return result;
        }

        /// <summary>
        ///     Register account
        /// </summary>
        /// <param name="binder"></param>
        /// <returns>Error strings, null if OK</returns>
        public async Task<string[]> Register(RegisterBinder binder) {

            string[] result;
            using (var client = CreateWebClient())
            {
                try
                {
                    client.UploadString(Uri + "/Register", JsonConvert.SerializeObject(binder));

                    HandleCookies(client.ResponseHeaders);

                    result = null;
                }
                catch (WebException e)
                {
                    result = ErrorResponse.Handle(e).Errors.ToArray();
                }
            }

            return result;
        }

        /// <summary>
        ///     Logs user off. Session token is deleted from client.
        /// </summary>
        public async Task LogOff() {
            using (var client = CreateWebClient())
            {
                client.DownloadString(Uri + "/LogOff");
            }

            AuthToken = null;
        }






        /// <summary>
        ///     Update account details
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Updated account details</returns>
        public async Task<UserDto> Edit(UserDto dto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Get user account details
        /// </summary>
        /// <returns>User account details</returns>
        public async Task<UserDto> Get() 
        {
            UserDto result;
            using (var client = CreateWebClient())
            {
                string retString = client.DownloadString(Uri);

                result = (UserDto) JsonConvert.DeserializeObject(retString, typeof(UserDto));
            }

            return result;
        }




        /// <summary>
        ///     Handle authentication related cookies
        /// </summary>
        public static void HandleCookies(WebHeaderCollection headers) {
            
            string token = headers.Get("Set-Cookie");
            if (token != null)
            {
                AuthToken = token;
            }
        }



    }
}
