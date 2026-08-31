namespace HireCore.ConsoleApp.Command
{
    public interface IAuditCommand
    {
        void Execute();
        void Undo();
        void PrintAudit();
    }
}
