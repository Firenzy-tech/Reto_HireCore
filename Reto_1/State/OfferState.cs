using HireCore.ConsoleApp.Domain;

namespace HireCore.ConsoleApp.State
{
    public class OfferState : ICandidateState
    {
        public string Name =>HireStatus.OFERTA;
        public void Advance(Candidate candidate, ICandidateState newState)
        {
            // Se añade la nueva etapa de Verificación de Referencias como opción válida[cite: 1]
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
