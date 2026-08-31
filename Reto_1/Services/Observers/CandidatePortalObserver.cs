using Reto_1.Entities;
using Reto_1.Services.NotificationServices;

namespace Reto_1.Services.Observers
{
    public class CandidatePortalObserver : IHireObserver
    {
        private readonly IServiceNotifications _serviceNotifications;

        public CandidatePortalObserver(IServiceNotifications serviceNotifications)
        {
            _serviceNotifications = serviceNotifications;
        }

        public Task Notify(HireEvent hireEvent)
        {
            if (hireEvent.IsInternal)
            {
                return Task.CompletedTask;
            }

            return _serviceNotifications.SendNotification(
                hireEvent.Candidate.Email,
                "Portal del candidato",
                hireEvent.Message);
        }
    }
}
