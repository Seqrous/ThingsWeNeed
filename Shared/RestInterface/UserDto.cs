using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThingsWeNeed.Shared
{
    public class UserDto
    {
        public UserDto()
        {
            this.Households = new HashSet<HouseholdDto>();
        }
        
        public string Id { get; set; }

        //[Required(ErrorMessage = "Email required")]
        [EmailAddress(ErrorMessage = "Email must be in correct format")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Username required")]
        public string Username { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        [Phone(ErrorMessage = "Phone number format incorrect")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<HouseholdDto> Households { get; private set; }
    }
}