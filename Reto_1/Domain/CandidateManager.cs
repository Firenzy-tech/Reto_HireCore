using HireCore.ConsoleApp.Command;
using HireCore.ConsoleApp.Observer;
using HireCore.ConsoleApp.State;

namespace HireCore.ConsoleApp.Domain
{
    public class CandidateManager
    {
        private readonly AuditHistory _auditHistory;
        private readonly NotificationManager _notificationManager;

        public CandidateManager(AuditHistory auditHistory, NotificationManager notificationManager)
        {
            _auditHistory = auditHistory;
            _notificationManager = notificationManager;
        }

        public void AdvanceState(Candidate candidate, ICandidateState newState, string author)
        {
            string oldState = candidate.CurrentState.Name;

            // 1. Ejecutar el cambio de estado con auditoría (Patrón Command)
            var command = new ChangeStateCommand(candidate, newState, author);
            _auditHistory.ExecuteCommand(command);

            // 2. Disparar notificaciones (Patrón Observer)
            _notificationManager.Notify(candidate, oldState, newState.Name);
        }
    }
}
