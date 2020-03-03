using System;
using System.Collections.Generic;
using System.Text;

namespace Uva.Allergie.Data.Entities
{
    public class IngredientEntity
    {
        public long IngredientId { get; set; }
        public long ProductId { get; set; }
        public string Vegetarian { get; set; }
        public string Text { get; set; }
        public string Vegan { get; set; }
        public string IngreId { get; set; }
        public int Rank { get; set; }
        public string Percent { get; set; }
        public string HasSubIngredients { get; set; }
    }
}
