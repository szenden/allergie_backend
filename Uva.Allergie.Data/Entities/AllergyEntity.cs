using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uva.Allergie.Data.Entities
{
    [Table("Allergies", Schema = "allergie_dev")]
    public class AllergyEntity : IAuditable
    {
        [Column("allergy_id")]
        [Key]
        public int AllergyId { get; set; }
        [Column("ingredient_id")]
        public int IngredientId { get; set; }
        [Column("ingredients_with_allergies")]
        public string IngredientsTextWithAllergens { get; set; }
        [Column("ingredients_analysis_tags")]
        public string IngredientsAnalysisTags { get; set; }
        [Column("allergens_from_ingredients")]
        public string AllergensFromIngredients { get; set; }
        [Column("allergens")]
        public string Allergens { get; set; }
        [Column("allergens_tags")]
        public string AllergensTags { get; set; }
        [Column("created_on")]
        public DateTime CreatedOn { get; set; }
        [Column("created_by")]
        public string CreatedBy { get; set; }
        [Column("modified_on")]
        public DateTime ModifiedOn { get; set; }
        [Column("modified_by")]
        public string ModifiedBy { get; set; }
    }
}
