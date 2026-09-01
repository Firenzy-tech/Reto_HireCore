using HireCore.ConsoleApp.Domain;

namespace HireCore.ConsoleApp.State
{
    public class AppliedState : ICandidateState
    {
        public string Name => HireStatus.APLICADO.ToString();

        public void Advance(Candidate candidate, ICandidateState newState)
        {
            if (newState is InterviewState || newState is RejectedState)
            {
                candidate.SetState(newState);
            }
            else
            {
                throw new InvalidOperationException($"Invalid transition: {Name} -> {newState.Name}");
            }
        }
    }
}
