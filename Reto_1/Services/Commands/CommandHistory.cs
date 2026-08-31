namespace Reto_1.Services.Commands
{
    public class CommandHistory : ICommandHistory
    {
        private readonly Stack<IHireCommand> _executed = new();
        private readonly List<IHireCommand> _log = new();

        public IReadOnlyList<IHireCommand> Log => _log;

        public void Push(IHireCommand command)
        {
            _executed.Push(command);
            _log.Add(command);
        }

        public IHireCommand? Pop() => _executed.Count == 0 ? null : _executed.Pop();
    }
}
