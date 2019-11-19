//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThingsWeNeed.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Thing
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Thing()
        {
            this.DefaultPrice = "0";
            this.Purchases = new HashSet<Purchase>();
        }
    
        public int ThingId { get; set; }
        public string Name { get; set; }
        public bool Needed { get; set; }
        public int HouseholdId { get; set; }
        public string DefaultPrice { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual Household Household { get; set; }
    }
}
