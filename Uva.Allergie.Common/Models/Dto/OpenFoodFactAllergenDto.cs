namespace Uva.Allergie.Common.Models.Dto
{
    public class OpenFoodFactAllergenDto
    {
        public Tag[] tags { get; set; }
        public int count { get; set; }
    }

    public class Tag
    {
        public string url { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public int products { get; set; }
        public string[] sameAs { get; set; }
    }

}
