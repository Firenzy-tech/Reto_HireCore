using HireCore.ConsoleApp.Domain;

namespace HireCore.ConsoleApp.Observer
{
    public class NotificationManager
    {
        private readonly List<ITransitionObserver> _observers = new();

        public void Subscribe(ITransitionObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(ITransitionObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(Candidate candidate, string oldState, string newState)
        {
            foreach (var observer in _observers)
            {
                observer.Update(candidate, oldState, newState);
            }
        }
    }
}
