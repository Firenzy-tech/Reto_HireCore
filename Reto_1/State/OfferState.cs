using HireCore.ConsoleApp.Domain;

namespace HireCore.ConsoleApp.State
{
    public class OfferState : ICandidateState
    {
        public string Name =>HireStatus.OFERTA.ToString();
        public void Advance(Candidate candidate, ICandidateState newState)
        {
            if (newState is ReferenceCheckState || newState is HiredState || newState is RejectedState)
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
