using Reto_1.Entities;
using Reto_1.Services.NotificationServices;

namespace Reto_1.Services.Observers
{
    public class HiringManagerObserver : IHireObserver
    {
        private const string RECIPIENT = "gerente.contratacion@hirecore.com";

        private readonly IServiceNotifications _serviceNotifications;

        public HiringManagerObserver(IServiceNotifications serviceNotifications)
        {
            _serviceNotifications = serviceNotifications;
        }

        public Task Notify(HireEvent hireEvent)
        {
            if (hireEvent.NewStatus != HireStatus.STATUS_OFERTA && hireEvent.NewStatus != HireStatus.STATUS_CONTRATADO)
            {
                return Task.CompletedTask;
            }

            return _serviceNotifications.SendNotification(RECIPIENT, "Gerente de contratación", hireEvent.Message);
        }
    }
}
