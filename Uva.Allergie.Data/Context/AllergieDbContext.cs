using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Uva.Allergie.Data.Entities;

namespace Uva.Allergie.Data.Context
{
    public class AllergieDbContext : DbContext, IAllergieDbContext
    {
        public AllergieDbContext(DbContextOptions<AllergieDbContext> options) : base(options)
        { }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<AllergyEntity> Allergies { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<IngredientEntity> Ingredients { get; set; }
        public DbSet<HelpTipEntity> HelpTips { get; set; }
        public DbSet<UserAllergyEntity> UserAllergies { get; set; }

        public async Task<bool> CheckConnection()
        {
            return await Database.CanConnectAsync();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {

            var EditedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

            //EditedEntities.ForEach(e =>
            //{
            //    e.Property("AmDate").CurrentValue = DateTime.Now;
            //    e.Property("AmBy").CurrentValue = (Database.GetDbConnection()).UserName;
            //});

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
