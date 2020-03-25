using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uva.Allergie.Data.Entities
{
    [Table("additives", Schema = "allergie_dev")]
    public class AdditiveEntity : IAuditable
    {
        [Column("addictive_id")]
        [Key]
        public int AddictiveId { get; set; }
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
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
        [Column("created_by")]
        public string CreatedBy { get; set; }
        [Column("modified_on")]
        public DateTime? ModifiedOn { get; set; }
        [Column("modified_by")]
        public string ModifiedBy { get; set; }
    }
}
