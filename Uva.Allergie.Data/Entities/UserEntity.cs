using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Uva.Allergie.Data.Entities
{
    [Table("Users", Schema = "allergie_dev")]
    public class UserEntity : IAuditable
    {
        [Column("user_id")]
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
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
