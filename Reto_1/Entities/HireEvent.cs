using MyApp.Models;

namespace Reto_1.Entities
{
    public class HireEvent
    {
        public Person Candidate { get; set; } = new Person();

        public string PreviousStatus { get; set; } = string.Empty;

        public string NewStatus { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public bool IsInternal { get; set; }

        public DateTime OccurredAt { get; set; }
    }
}
