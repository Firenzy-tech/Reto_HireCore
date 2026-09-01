using HireCore.ConsoleApp.Domain;

namespace HireCore.ConsoleApp.State
{
    public class TechnicalTestState: ICandidateState
    {
        public string Name => HireStatus.PRUEBA_TECNICA.ToString();

        public void Advance(Candidate candidate, ICandidateState newState)
        {
            if (newState is OfferState || newState is RejectedState)
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
