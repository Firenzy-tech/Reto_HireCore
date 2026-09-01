using HireCore.ConsoleApp.Memento;
using HireCore.ConsoleApp.State;

namespace HireCore.ConsoleApp.Domain
{
    public class Candidate(string name)
    {
        public string Name { get; } = name;
        public ICandidateState CurrentState { get; private set; } = new AppliedState();

        public void SetState(ICandidateState state)
        {
            CurrentState = state;
        }

        // El Gestor o Comando llama a este método para solicitar un avance
        public void RequestTransition(ICandidateState newState)
        {
            CurrentState.Advance(this, newState);
        }

        // Métodos de auditoría/reversión
        public CandidateMemento SaveState() => new CandidateMemento(CurrentState);

        public void RestoreState(CandidateMemento memento)
        {
            CurrentState = memento.State;
        }
    }
}
