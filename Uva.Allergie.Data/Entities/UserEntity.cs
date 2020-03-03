using System;
using System.Collections.Generic;
using System.Text;

namespace Uva.Allergie.Data.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
    }
}
