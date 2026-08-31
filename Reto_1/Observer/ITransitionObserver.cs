using HireCore.ConsoleApp.Domain;

namespace HireCore.ConsoleApp.Observer
{
    public interface ITransitionObserver
    {
        void Update(Candidate candidate, string oldState, string newState);
    }
}
