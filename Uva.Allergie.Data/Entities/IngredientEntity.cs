using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uva.Allergie.Data.Entities
{
    [Table("Ingredients", Schema = "allergie_dev")]
    public class IngredientEntity : IAuditable
    {
        [Column("ingredient_id")]
        [Key]
        public int IngredientId { get; set; }
        [Column("product_id")]
        public int ProductId { get; set; }
        [Column("vegetarian")]
        public string Vegetarian { get; set; }
        [Column("text")]
        public string Text { get; set; }
        [Column("vegan")]
        public string Vegan { get; set; }
        [Column("original_ingredient_id")]
        public string IngreId { get; set; }
        [Column("rank")]
        public int Rank { get; set; }
        [Column("ing_percent")]
        public string Percent { get; set; }
        [Column("has_sub_ingredients")]
        public string HasSubIngredients { get; set; }
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
