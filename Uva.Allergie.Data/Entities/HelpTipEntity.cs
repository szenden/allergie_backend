using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uva.Allergie.Data.Entities
{
    [Table("HelpTips", Schema = "allergie_dev")]
    public class HelpTipEntity : IAuditable
    {
        [Column("helptip_id")]
        [Key]
        public int Id { get; set; }
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
