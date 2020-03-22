using System;
using System.Collections.Generic;
using System.Text;

namespace Uva.Allergie.Common.Models
{
    public class UserInput
    {
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserUID { get; set; }
        public string Provider { get; set; }
        public string PictureUrl { get; set; }
        public string Locale { get; set; }
        public List<int> AllergyIds { get; set; }
    }
}
