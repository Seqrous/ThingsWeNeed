
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ThingsWeNeed.Data.Household;
using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Data.User;

namespace ThingsWeNeed.Data.Thing
{
    [Table("Thing", Schema = "TWN")]
    public class ThingEntity
    {
        public ThingEntity()
        {
            this.DefaultPrice = 0;
            this.Needed = false;
            this.Show = true;
        }
        

        [Key]
        public int ThingId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int HouseholdId { get; set; }

        [Required]
        public bool Show { get; set; }      // For referential integrity
                                            // When deleting, dont actually delete the thing, but make it hidden

        [Required]
        public bool Needed { get; set; }

        [Required]
        public double DefaultPrice { get; set; }


        [ForeignKey("HouseholdId")]
        public virtual HouseholdEntity Household { get; set; }
    }
}