namespace Uva.Allergie.Common.Models
{
    public class AppSettingsOption
    {
        public Connectionstrings ConnectionStrings { get; set; }
        public Service Service { get; set; }
    }

    public class Connectionstrings
    {
        public string Default { get; set; }
    }

    public class Service
    {
        public string ProductApi { get; set; }
        public string HelpTipsApi { get; set; }
        public string MedicalApi { get; set; }
        public string PlacesApi { get; set; }
    }

}
