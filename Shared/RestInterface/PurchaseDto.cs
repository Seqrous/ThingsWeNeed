using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingsWeNeed.Shared
{
    public class PurchaseDto
    {
        public int PurchaseId { get; set; }

        public DateTime MadeOn { get; set; }

        [Required]
        public double Price { get; set; }

        public string MadeById { get; set; }

        [Required]
        public int ThingId { get; set; } 


        public dynamic Thing { get; set; }

        public dynamic MadeBy { get; set; }
    }
}
