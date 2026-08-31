using Reto_1.Entities.DTOs;

namespace Reto_1.Services.Commands
{
    public interface IHireCommand
    {
        string ExecutedBy { get; }

        DateTime ExecutedAt { get; }

        string? UndoneBy { get; }

        DateTime? UndoneAt { get; }

        string Description { get; }

        Task<ResponseDto> Execute();

        Task Undo(string undoneBy);
    }
}
