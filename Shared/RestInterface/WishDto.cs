using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ThingsWeNeed.Shared
{
    public class WishDto
    {
        public WishDto()
        {
            Links = new LinkedList<LinkDto>();
        }

        public int WishId { get; set; }

        [Required(ErrorMessage = "Name required")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Max price required")]
        public double MaxPrice { get; set; }

        public bool Show { get; set; }

        public string MadeById { get; set; }

        public string GrantedById { get; set; }

        public DateTime? MadeOn { get; set; }

        public DateTime? GrantedOn { get; set; }

        public double ExtraPay { get; set; }


        
        public dynamic User { get; set; }

        public ICollection<LinkDto> Links { get; private set; }
    }
}
