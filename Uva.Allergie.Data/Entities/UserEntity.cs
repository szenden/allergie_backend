using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Uva.Allergie.Data.Entities
{
    [Table("users", Schema = "allergie_dev")]
    public class UserEntity : IAuditable
    {
        [Column("user_id")]
        [Key]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("email_verified")]
        public bool EmailVerified { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("uid")]
        public string UserUID { get; set; }
        [Column("provider")]
        public string Provider { get; set; }
        [Column("picture_url")]
        public string PictureUrl { get; set; }
        [Column("locale")]
        public string Locale { get; set; }
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
