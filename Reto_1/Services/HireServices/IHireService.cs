using Reto_1.Entities.DTOs;

namespace Reto_1.Services.HireServices
{
    public interface IHireService
    {
        Task<ResponseDto> ChangeStatus(string documentType, string documentNumber, string newStatus);

    }
}
