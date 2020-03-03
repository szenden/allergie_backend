using System;
using System.Collections.Generic;
using System.Text;

namespace Uva.Allergie.Data.Entities
{
    public class UserAllergyEntity
    {
        public Guid UserId { get; set; }
        public virtual UserEntity User { get; set; }
        public int AllergyId { get; set; }
        public virtual AllergyEntity Allergy { get; set; }
    }
}
