using Reto_1.Entities.DTOs;
using Reto_1.Services.Commands;

namespace Reto_1.Services.HireServices
{
    public interface IHireService
    {
        Task<ResponseDto> ChangeStatus(string documentType, string documentNumber, string newStatus, string executedBy);

        Task<ResponseDto> Undo(string executedBy);

        IReadOnlyList<IHireCommand> AuditTrail();
    }
}
