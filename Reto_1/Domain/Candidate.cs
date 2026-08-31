using HireCore.ConsoleApp.Memento;
using HireCore.ConsoleApp.State;

namespace HireCore.ConsoleApp.Domain
{
    public class Candidate
    {
        public string Name { get; }
        public ICandidateState CurrentState { get; private set; }

        public Candidate(string name)
        {
            Name = name;
            CurrentState = new AppliedState(); 
        }

        // Este método es usado SOLO por las clases State para confirmar el cambio interno
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
