using Reto_1.Entities;
using Reto_1.Services.NotificationServices;

namespace Reto_1.Services.Observers
{
    public class RecruiterObserver : IHireObserver
    {
        private readonly IServiceNotifications _serviceNotifications;

        public RecruiterObserver(IServiceNotifications serviceNotifications)
        {
            _serviceNotifications = serviceNotifications;
        }

        public Task Notify(HireEvent hireEvent)
        {
            return _serviceNotifications.SendNotification(
                hireEvent.Candidate.RecruiterEmail,
                "Reclutador",
                hireEvent.Message);
        }
    }
}
