using MyApp.Models;
using Reto_1.Entities;
using Reto_1.Entities.DTOs;
using Reto_1.Services.Commands;
using Reto_1.Services.Observers;

namespace Reto_1.Services.HireServices
{
    public class HireService : IHireService
    {
        private readonly IEnumerable<IHireObserver> _observers;
        private readonly ICommandHistory _history;

        private readonly List<Person> _person = new()
        {
            new Person
            {
                Id = 1,
                Name = "Ana Torres",
                Document = new Document { DocumentType = "CC", DocumentNumber = "123456789" },
                Address = "Calle 45 #12-30",
                Email = "ana.torres@correo.com",
                RecruiterEmail = "reclutador@hirecore.com",
                Birthdate = new DateTime(1995, 4, 12)
            }
        };

        public HireService(IEnumerable<IHireObserver> observers, ICommandHistory history)
        {
            _observers = observers;
            _history = history;
        }

        public async Task<ResponseDto> ChangeStatus(string documentType, string documentNumber, string newStatus, string executedBy)
        {
            var candidato = _person.FirstOrDefault(c =>
                c.Document.DocumentType == documentType && c.Document.DocumentNumber == documentNumber);

            if (candidato == null)
            {
                return new ResponseDto
                {
                    Success = false,
                    Message = "Candidato no encontrado"
                };
            }

            try
            {
                var command = new ChangeStatusCommand(candidato, newStatus, executedBy, _observers);
                var result = await command.Execute();

                if (result.Success)
                {
                    _history.Push(command);
                }

                return result;
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResponseDto> Undo(string executedBy)
        {
            var command = _history.Pop();

            if (command == null)
            {
                return new ResponseDto
                {
                    Success = false,
                    Message = "No hay cambios para deshacer"
                };
            }

            await command.Undo(executedBy);

            return new ResponseDto
            {
                Success = true,
                Message = $"Cambio deshecho: {command.Description}",
                Data = command.Description
            };
        }

        public IReadOnlyList<IHireCommand> AuditTrail() => _history.Log;
    }
}
