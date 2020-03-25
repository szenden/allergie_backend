using System.Collections.Generic;

namespace Uva.Allergie.Common.Models
{
    public class ProductOutput
    {
        public UserInfo UserInfo { get; set; }
        public ProductInfo ProductInfo { get; set; }
        public List<IngredientOutput> Ingredients { get; set; }
        public List<AdditiveOutput> Additives { get; set; }
        public List<AllergyOutput> Allergens { get; set; }
        public List<AllergyOutput> UserAllergens { get; set; }

    }

    public class UserInfo
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Type { get; set; }
    }

    public class ProductInfo
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public string Brands { get; set; }
        public string NutritionGrades { get; set; }
        public string ImageUrl { get; set; }
        public string Thumbnail { get; set; }
        public string KeyWords { get; set; }
        public string NutrientLevels { get; set; }
        public string Quantity { get; set; }
        public string Creator { get; set; }
        public string Nutriments { get; set; }
        public string Categories { get; set; }
        public string IngredientText { get; set; }
    }

    public class IngredientOutput
    {
        public int IngredientId { get; set; }
        public int ProductId { get; set; }
        public string Vegetarian { get; set; }
        public string Text { get; set; }
        public string Vegan { get; set; }
        public string IngreId { get; set; }
        public int Rank { get; set; }
        public string Percent { get; set; }
        public string HasSubIngredients { get; set; }
    }

    public class AllergyOutput
    {
        public int AllergyId { get; set; }
        public int IngredientId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string OriginalId { get; set; }
        public int Products { get; set; }
        public string SameAs { get; set; }
        public string IngredientsTextWithAllergens { get; set; }
        public string IngredientsAnalysisTags { get; set; }
        public string AllergensFromIngredients { get; set; }
        public string Allergens { get; set; }
        public string AllergensTags { get; set; }
        public string PotentialReactions { get; set; }
        public string Remarks { get; set; }
    }

    public class AdditiveOutput
    {
        public int AddictiveId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string OriginalId { get; set; }
        public int Products { get; set; }
        public string SameAs { get; set; }
    }
}
