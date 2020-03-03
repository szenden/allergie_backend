using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Uva.Allergie.Data.Entities;

namespace Uva.Allergie.Data.Context
{
    public interface IAllergieDbContext
    {
        DbSet<ProductEntity> Products { get; set; }
        DbSet<AllergyEntity> Allergies { get; set; }
        DbSet<UserEntity> Users { get; set; }
        DbSet<IngredientEntity> Ingredients { get; set; }
        DbSet<HelpTipEntity> HelpTips { get; set; }
        DbSet<UserAllergyEntity> UserAllergies { get; set; }
        Task<bool> CheckConnection();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
