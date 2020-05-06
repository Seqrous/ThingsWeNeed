using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Data.User;

namespace ThingsWeNeed.Data.Purchase
{
    [Table("Purchases", Schema = "TWN")]
    public class PurchaseEntity
    {
        [Key]
        public int PurchaseId { get; set; }

        [Required]
        public int ThingId { get; set; }

        [Required]
        public string MadeById { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public DateTime MadeOn { get; set; }


        [ForeignKey("ThingId")]
        public virtual ThingEntity Thing { get; private set; }

        [ForeignKey("MadeById")]
        public virtual UserEntity MadeBy { get; private set; }

    }
}
