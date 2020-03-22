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
        public DbSet<AdditiveEntity> Additives { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<AllergyEntity> Allergies { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<IngredientEntity> Ingredients { get; set; }
        public DbSet<HelpTipEntity> HelpTips { get; set; }
        public DbSet<UserAllergyEntity> UserAllergies { get; set; }
        public DbSet<NewsArticleEntity> NewsArticles { get; set; }
        public DbSet<WikiAllergyEntity> WikiAllergies { get; set; }
        public async Task<bool> CheckConnection()
        {
            return await Database.CanConnectAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAllergyEntity>()
                .HasKey(o => new { o.UserId, o.AllergyId });
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {

            var EditedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified || E.State == EntityState.Added).ToList();

            EditedEntities.ForEach(e =>
            {
                switch (e.State)
                {
                    case EntityState.Added:
                        e.Property("CreatedOn").CurrentValue = DateTime.Now;
                        e.Property("CreatedBy").CurrentValue = ((Npgsql.NpgsqlConnection)Database.GetDbConnection()).UserName;
                        break;
                    case EntityState.Modified:
                        e.Property("ModifiedOn").CurrentValue = DateTime.Now;
                        e.Property("ModifiedBy").CurrentValue = ((Npgsql.NpgsqlConnection)Database.GetDbConnection()).UserName;
                        break;
                }

            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
