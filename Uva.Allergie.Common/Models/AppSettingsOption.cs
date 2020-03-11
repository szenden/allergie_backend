namespace Uva.Allergie.Common.Models
{
    public class AppSettingsOption
    {
        public Connectionstrings ConnectionStrings { get; set; }
        public Service Service { get; set; }
        public ApiKeys ApiKeys { get; set; }
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
        public string Newspi { get; set; }
    }
    public class ApiKeys
    {
        public string HealthNews { get; set; }
    }

}
