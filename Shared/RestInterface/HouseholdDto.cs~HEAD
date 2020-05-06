using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ThingsWeNeed.Shared
{
    public class HouseholdDto
    {
        public int HouseholdId { get; set; }

        [Required(ErrorMessage = "A name is required. This can be anything.")]
        public string Name { get; set; }

        public AddressDto Address { get; set; }

        public ICollection<ThingDto> Things { get; set; }

        public ICollection<UserDto> Users { get; set; }
    }

    [ComplexType]
    public class AddressDto
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
    }
}