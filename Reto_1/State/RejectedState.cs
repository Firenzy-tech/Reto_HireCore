using HireCore.ConsoleApp.Domain;

namespace HireCore.ConsoleApp.State
{
    public class RejectedState : ICandidateState
    {
        public string Name => HireStatus.RECHAZADO.ToString();
        public void Advance(Candidate candidate, ICandidateState newState) =>
            throw new InvalidOperationException($"Process terminated. Cannot advance from {Name}.");
    }
}
