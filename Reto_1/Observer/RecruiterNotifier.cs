using HireCore.ConsoleApp.Domain;

namespace HireCore.ConsoleApp.Observer
{
    internal class RecruiterNotifier : ITransitionObserver
    {
        public void Update(Candidate candidate, string oldState, string newState)
        {
            // Lógica para notificar al reclutador sobre el cambio de estado del candidato
            Console.WriteLine($"[Email a Reclutador] {candidate.Name} pasó de {oldState} a {newState}.");
        }
    }
}
