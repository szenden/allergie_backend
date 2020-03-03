namespace Uva.Allergie.Common.Models
{
    public class BaseOutput<T>
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public T Payload { get; set; }
    }
}
