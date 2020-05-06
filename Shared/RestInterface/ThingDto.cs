using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ThingsWeNeed.Shared
{
    public class ThingDto
    {
        public ThingDto()
        {
            Links = new LinkedList<LinkDto>();
        }

        public int ThingId { get; set; }

        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Household Id required")]
        public int HouseholdId { get; set; }

        public bool Needed { get; set; }

        public double DefaultPrice { get; set; }

        public bool Show { get; set; }

        public dynamic Household { get; set; }

        public ICollection<LinkDto> Links { get; private set;}
        
    }
}