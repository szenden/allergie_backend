using System;
using System.Collections.Generic;
using System.Text;

namespace Uva.Allergie.Data.Entities
{
    public class AllergyEntity
    {
        public long AllergyId { get; set; }
        public string IngredientsTextWithAllergens { get; set; }
        public string IngredientsAnalysisTags { get; set; }
    }
}
