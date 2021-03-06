﻿using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Uva.Allergie.Data.Entities;

namespace Uva.Allergie.Data.Context
{
    public interface IAllergieDbContext
    {
        DbSet<AdditiveEntity> Additives { get; set; }
        DbSet<ProductEntity> Products { get; set; }
        DbSet<AllergyEntity> Allergies { get; set; }
        DbSet<UserEntity> Users { get; set; }
        DbSet<IngredientEntity> Ingredients { get; set; }
        DbSet<HelpTipEntity> HelpTips { get; set; }
        DbSet<UserAllergyEntity> UserAllergies { get; set; }
        DbSet<NewsArticleEntity> NewsArticles { get; set; }
        DbSet<WikiAllergyEntity> WikiAllergies { get; set; }
        Task<bool> CheckConnection();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
