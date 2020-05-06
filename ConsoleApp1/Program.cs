using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.Shared;
using ThingsWeNeed.Shared.REST;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main()
        {
            string[] errors = MainAsync().GetAwaiter().GetResult();

            if (errors != null)
            {
                foreach (string err in errors)
                {
                    Console.WriteLine(err);
                }
            }

            Console.Read();
        }

        public static async Task<string[]> MainAsync() {

            RestClient.SetDomain("https://localhost:44371");

            ClientUserManager manager = new ClientUserManager();
            ThingRest things = new ThingRest();
            HouseholdRest households = new HouseholdRest();

            string random = new Random().Next().ToString();

            string[] errors = await manager.Register(new RegisterBinder()
            {
                Username = $"UserNr{random}",
                Email = $"BeepedyBoopidy{random}@gmail.com",
                FName = $"Name{random}",
                LName = $"LName{random}",
                Password = $"Password{random}",
                ConfirmPassword = $"Password{random}"
            });


            ThingDto dto = things.Get(1);
            dto.Household = households.Get(dto.HouseholdId);
            Console.WriteLine(JsonConvert.SerializeObject(dto));


            //      dto = complete thing, ready for use


            return "Oi";
            
        }
    }
}
