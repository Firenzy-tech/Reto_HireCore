using HireCore.ConsoleApp.Domain;

namespace HireCore.ConsoleApp.State
{
    internal class InterviewState: ICandidateState
    {
        public string Name => HireStatus.ENTREVISTA.ToString();

        public void Advance(Candidate candidate, ICandidateState newState)
        {
            // Se añade la nueva etapa de Prueba Técnica como opción válida[cite: 1]
            if (newState is TechnicalTestState || newState is OfferState || newState is RejectedState)
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
