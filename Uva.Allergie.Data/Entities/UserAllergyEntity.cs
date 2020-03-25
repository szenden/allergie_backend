using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uva.Allergie.Data.Entities
{
    [Table("user_allergies", Schema = "allergie_dev")]
    public class UserAllergyEntity : IAuditable
    {
        [Column("user_id")]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }
        [Column("allergy_id")]
        public int AllergyId { get; set; }
        public virtual AllergyEntity Allergy { get; set; }
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
