using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uva.Allergie.Data.Entities
{
    [Table("products", Schema="allergie_dev")]
    public class ProductEntity
    {
        [Column("product_id")]
        [Key]
        public long Id { get; set; }
        [Column("barcode")]
        public string Barcode { get; set; }
        [Column("product_name")]
        public string ProductName { get; set; }
        [Column("brands")]
        public string Brands { get; set; }
        [Column("nutrition_grades")]
        public string NutritionGrades { get; set; }
        [Column("product_image")]
        public string ImageUrl { get; set; }
        [Column("product_thumbnail")]
        public string Thumbnail { get; set; }
        [Column("key_words")]
        public string KeyWords { get; set; }
        [Column("nutritient_levels")]
        public string NutrientLevels { get; set; }
        [Column("quantity")]
        public string Quantity { get; set; }
        [Column("creator")]
        public string Creator { get; set; }
        [Column("nutriments")]
        public string Nutriments { get; set; }
        [Column("categories")]
        public string Categories { get; set; }
        [Column("raw_json")]
        public string RawJson { get; set; }
    }
}
