using HireCore.ConsoleApp.Domain;

namespace HireCore.ConsoleApp.State
{
    public class HiredState : ICandidateState
    {
        public string Name => HireStatus.CONTRATADO.ToString();
        public void Advance(Candidate candidate, ICandidateState newState) =>
            throw new InvalidOperationException("Process completed. Cannot advance from HIRED.");
    }
}
