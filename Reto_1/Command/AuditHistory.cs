namespace HireCore.ConsoleApp.Command
{
    public class AuditHistory
    {
        private readonly Stack<IAuditCommand> _history = new();

        public void ExecuteCommand(IAuditCommand command)
        {
            command.Execute();
            _history.Push(command); 
        }

        public void UndoLast()
        {
            if (_history.Count > 0)
            {
                IAuditCommand lastCommand = _history.Pop();
                lastCommand.Undo();
            }
            else
            {
                Console.WriteLine("No hay acciones para deshacer.");
            }
        }

        public void ShowAuditTrail()
        {
            Console.WriteLine("\n--- Historial de Auditoría ---");
            foreach (var cmd in _history)
            {
                cmd.PrintAudit();
            }
            Console.WriteLine("------------------------------\n");
        }

    }
}
