using System.Collections.Generic;

namespace Uva.Allergie.Common.Models.Dto
{
    public class AllergyAllDto 
    { 
        public List<Allergy> Allergies { get; set; }
    }
    public class Allergy
    {
        public int AllergyId { get; set; }
        public string Name { get; set; }
        public bool isChecked { get; set; }
    }

    public class AllergyDto
    {
        public int AllergyId { get; set; }
        public int IngredientId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string OriginalId { get; set; }
        public int Products { get; set; }
        public string SameAs { get; set; }
        public string IngredientsTextWithAllergens { get; set; }
        public string AllergensFromIngredients { get; set; }
        public string Allergens { get; set; }
        public string AllergensTags { get; set; }
    }
}
