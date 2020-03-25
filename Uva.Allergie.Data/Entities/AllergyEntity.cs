using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uva.Allergie.Data.Entities
{
    [Table("allergies", Schema = "allergie_dev")]
    public class AllergyEntity : IAuditable
    {
        [Column("allergy_id")]
        [Key]
        public int AllergyId { get; set; }
        [Column("ingredient_id")]
        public int IngredientId { get; set; }
        [Column("url")]
        public string Url { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("original_id")]
        public string OriginalId { get; set; }
        [Column("products")]
        public int Products { get; set; }
        [Column("same_as")]
        public string SameAs { get; set; }
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
        public DateTime? CreatedOn { get; set; }
        [Column("created_by")]
        public string CreatedBy { get; set; }
        [Column("modified_on")]
        public DateTime? ModifiedOn { get; set; }
        [Column("modified_by")]
        public string ModifiedBy { get; set; }
    }

   [Table("allergicwikipedia", Schema = "allergie_dev")]
    public class WikiAllergyEntity
    {
        [Column("allergicwiki_id")]
        [Key]
        public int AllergyWikiId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("potential_reactions")]
        public string PotentialReactions { get; set; }
        [Column("remaks")]
        public string Remarks { get; set; }
    }
}
