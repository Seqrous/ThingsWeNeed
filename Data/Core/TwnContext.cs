using System.Data.Entity;

using ThingsWeNeed.Data.Household;
using ThingsWeNeed.Data.User;
using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Data.Wish;
using ThingsWeNeed.Data.Purchase;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ThingsWeNeed.Data.Core
{
    public class TwnContext : IdentityDbContext<UserEntity>
    {
        public TwnContext() : base()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TwnContext>());
        }

        public DbSet<ThingEntity> Things { get; set; }

        public DbSet<HouseholdEntity> Households { get; set; }

        public DbSet<PurchaseEntity> Purchases { get; set; }

        public DbSet<WishEntity> Wishes { get; set; }

        public static TwnContext Create() {
            return new TwnContext();
        }
    }
}