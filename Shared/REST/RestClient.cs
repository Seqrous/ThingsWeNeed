using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ThingsWeNeed.Shared.REST
{
    public abstract class RestClient
    {
        /// <summary>
        ///  example:  "https://localhost:44371"
        /// </summary>
        protected static string DomainName { get; set; }

        /// <summary>
        /// example:   "api/Things"
        /// </summary>
        protected string RouteString { get; set; }

        /// <summary>
        /// The full URI of the resource
        /// </summary>
        public string Uri { 
            get => DomainName + "/" + RouteString; 
        }


        protected static string AuthToken { get; set; }
        
        //public RestClient(string uri)
        //{
        //    ServerUri = uri;
        //}

        public static WebClient CreateWebClient() {
            WebClient client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            client.Headers.Add("Accept", "application/json");

            if (AuthToken != null)
            {
                client.Headers.Add("Cookie", AuthToken);
            }

            return client;
        }

        public static void SetDomain(string uri) {
            DomainName = uri;
        }
    }
}