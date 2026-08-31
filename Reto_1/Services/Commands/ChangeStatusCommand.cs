using MyApp.Models;
using Reto_1.Entities;
using Reto_1.Entities.DTOs;
using Reto_1.Services.Observers;

namespace Reto_1.Services.Commands
{
    public class ChangeStatusCommand : IHireCommand
    {
        private readonly Person _candidate;
        private readonly string _newStatus;
        private readonly IEnumerable<IHireObserver> _observers;

        private CandidateMemento? _memento;
        private string _previousStatus = string.Empty;

        public ChangeStatusCommand(Person candidate, string newStatus, string executedBy, IEnumerable<IHireObserver> observers)
        {
            _candidate = candidate;
            _newStatus = newStatus;
            _observers = observers;
            ExecutedBy = executedBy;
        }

        public string ExecutedBy { get; }

        public DateTime ExecutedAt { get; private set; }

        public string? UndoneBy { get; private set; }

        public DateTime? UndoneAt { get; private set; }

        public string Description => $"{_candidate.Name}: {_previousStatus} -> {_newStatus}";

        public async Task<ResponseDto> Execute()
        {
            var next = _candidate.State.Next(_newStatus);

            if (next == null)
            {
                return new ResponseDto
                {
                    Success = false,
                    Message = $"Transición inválida: {_candidate.State.Name} -> {_newStatus}"
                };
            }

            _memento = _candidate.Save();
            _previousStatus = _candidate.State.Name;
            _candidate.State = next;
            ExecutedAt = DateTime.Now;

            await Publish(_previousStatus, next.Name, next.Message(_candidate.Name), false);

            return new ResponseDto
            {
                Success = true,
                Message = $"Estado cambiado a {_newStatus}",
                Data = _candidate.State.Name
            };
        }

        public async Task Undo(string undoneBy)
        {
            if (_memento == null)
            {
                return;
            }

            _candidate.Restore(_memento);
            UndoneBy = undoneBy;
            UndoneAt = DateTime.Now;

            await Publish(
                _newStatus,
                _candidate.State.Name,
                $"Se revirtió el cambio de {_candidate.Name}: {_newStatus} -> {_candidate.State.Name}",
                true);
        }

        private async Task Publish(string previousStatus, string newStatus, string message, bool isInternal)
        {
            var hireEvent = new HireEvent
            {
                Candidate = _candidate,
                PreviousStatus = previousStatus,
                NewStatus = newStatus,
                Message = message,
                IsInternal = isInternal,
                OccurredAt = DateTime.Now
            };

            foreach (var observer in _observers)
            {
                await observer.Notify(hireEvent);
            }
        }
    }
}
