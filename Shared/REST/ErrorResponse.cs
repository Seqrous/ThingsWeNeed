using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ThingsWeNeed.Shared.REST
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; private set; }

        public string Message { get; set; }
        public IDictionary<string, string[]> ModelState { get; set; }
        

        public static ErrorResponse Handle(WebException e) {

            string errorString;
            using (var reader = new StreamReader(e.Response.GetResponseStream()))
            {
                errorString = reader.ReadToEnd();
            }
            //var obj = JsonConvert.DeserializeObject(errorString);

            ErrorResponse resp = (ErrorResponse) JsonConvert.DeserializeObject(errorString, typeof(ErrorResponse));

            foreach (string error in resp.ModelState.Values.FirstOrDefault()) {
                resp.Errors.Add(error);
            }

            return resp;
        }
    }
}
