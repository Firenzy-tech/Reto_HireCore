using HireCore.ConsoleApp.Domain;
using HireCore.ConsoleApp.Memento;
using HireCore.ConsoleApp.State;

namespace HireCore.ConsoleApp.Command
{
    public class ChangeStateCommand(Candidate candidate, ICandidateState newState, string author) : IAuditCommand
    {
        private readonly Candidate _candidate = candidate;
        private readonly ICandidateState _newState = newState;
        private readonly string _author = author;
        private readonly DateTime _timestamp = DateTime.UtcNow;

        private CandidateMemento? _previousState;

        public void Execute()
        {
            _previousState = _candidate.SaveState();

            _candidate.RequestTransition(_newState);

            Console.WriteLine($"[Ejecutado] {_author} cambió el estado a '{_newState.Name}' en {_timestamp:HH:mm:ss}");
        }

        public void Undo()
        {
            if (_previousState != null)
            {
                _candidate.RestoreState(_previousState);
                Console.WriteLine($"[Revertido] Acción deshecha por {_author}. Estado restaurado a '{_previousState.State.Name}'");
            }
        }

        public void PrintAudit()
        {
            Console.WriteLine($"- Intento hacia '{_newState.Name}' por {_author} el {_timestamp}");
        }
    }
}
