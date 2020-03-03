using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Uva.Allergie.Data.Entities
{
    [Table("UserAllergies", Schema = "allergie_dev")]
    public class UserAllergyEntity : IAuditable
    {
        [Column("user_id")]
        [Key]
        public Guid UserId { get; set; }
        public virtual UserEntity User { get; set; }
        public int AllergyId { get; set; }
        public virtual AllergyEntity Allergy { get; set; }
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
