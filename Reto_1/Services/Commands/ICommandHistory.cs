namespace Reto_1.Services.Commands
{
    public interface ICommandHistory
    {
        IReadOnlyList<IHireCommand> Log { get; }

        void Push(IHireCommand command);

        IHireCommand? Pop();
    }
}
