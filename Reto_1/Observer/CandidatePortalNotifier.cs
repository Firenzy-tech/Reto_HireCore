using HireCore.ConsoleApp.Domain;

namespace HireCore.ConsoleApp.Observer
{
    public class CandidatePortalNotifier : ITransitionObserver
    {
        public void Update(Candidate candidate, string oldState, string newState)
        {
            Console.WriteLine($"[Portal Web] Hola {candidate.Name}, el estado de tu aplicación se actualizó a {newState}.");
        }
    }
}
