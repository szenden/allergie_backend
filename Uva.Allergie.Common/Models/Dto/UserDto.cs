using System.Collections.Generic;

namespace Uva.Allergie.Common.Models.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string LastName { get; set; }
        public string UserUID { get; set; }
        public string Provider { get; set; }
        public string PictureUrl { get; set; }
        public string Locale { get; set; }
        public List<AllergyDto> UserAllergis { get; set; }
    }
}
