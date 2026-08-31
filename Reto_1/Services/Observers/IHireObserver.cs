using Reto_1.Entities;

namespace Reto_1.Services.Observers
{
    public interface IHireObserver
    {
        Task Notify(HireEvent hireEvent);
    }
}
