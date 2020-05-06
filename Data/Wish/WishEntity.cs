using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.Data.User;

namespace ThingsWeNeed.Data.Wish
{

    [Table("Wish", Schema = "TWN")]
    public class WishEntity
    {
        public  WishEntity()
        {

        }
        [Key]
    public int WishId { get; set; }
        [Required]
        public double MaxPrice { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public double ExtraPay { get; set; }
        [Required]
        public string MadeById { get; set; }
        [Required]
        public DateTime MadeOn { get; set; }

        public string GrantedById { get; set; }

        public DateTime? GrantedOn { get; set; }

        public bool Show { get; set; }

        [ForeignKey("MadeById")]
        public virtual UserEntity MadeBy { get; set; }

        [ForeignKey("GrantedById")]
        public virtual UserEntity GrantedBy { get; set; }


        /*
                [ForeignKey("MadeById")]
                public virtual UserEntity Made { get; set; }

            */
    }
}
