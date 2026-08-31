using Reto_1.Entities;
using Reto_1.Services.NotificationServices;

namespace Reto_1.Services.Observers
{
    public class PayrollObserver : IHireObserver
    {
        private const string RECIPIENT = "nomina@hirecore.com";

        private readonly IServiceNotifications _serviceNotifications;

        public PayrollObserver(IServiceNotifications serviceNotifications)
        {
            _serviceNotifications = serviceNotifications;
        }

        public Task Notify(HireEvent hireEvent)
        {
            if (hireEvent.NewStatus != HireStatus.STATUS_CONTRATADO)
            {
                return Task.CompletedTask;
            }

            return _serviceNotifications.SendNotification(RECIPIENT, "Nómina", hireEvent.Message);
        }
    }
}
