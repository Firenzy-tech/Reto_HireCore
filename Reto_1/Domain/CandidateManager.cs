using HireCore.ConsoleApp.Command;
using HireCore.ConsoleApp.Observer;
using HireCore.ConsoleApp.State;

namespace HireCore.ConsoleApp.Domain
{
    public class CandidateManager(AuditHistory auditHistory, NotificationManager notificationManager)
    {
        private readonly AuditHistory _auditHistory = auditHistory;
        private readonly NotificationManager _notificationManager = notificationManager;

        public void AdvanceState(Candidate candidate, ICandidateState newState, string author)
        {
            string oldStateName = candidate.CurrentState.Name;

            var command = new ChangeStateCommand(candidate, newState, author);
            _auditHistory.ExecuteCommand(command);

            _notificationManager.Notify(candidate, oldStateName, candidate.CurrentState.Name);
        }
    }
}