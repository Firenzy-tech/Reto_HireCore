using HireCore.ConsoleApp.Command;
using HireCore.ConsoleApp.Domain;
using HireCore.ConsoleApp.State;

namespace HireCore.ConsoleApp;

static class Program
{
    static void Main()
    {
        var auditHistory = new AuditHistory();
        var candidate = new Candidate("Laura Gómez");

        Console.WriteLine($"Estado inicial: {candidate.CurrentState.Name}");

        try
        {
            var cmd1 = new ChangeStateCommand(candidate, new InterviewState(), "HR_User");
            auditHistory.ExecuteCommand(cmd1);

            var cmd2 = new ChangeStateCommand(candidate, new TechnicalTestState(), "Tech_Lead");
            auditHistory.ExecuteCommand(cmd2);

            Console.WriteLine("\n--- Intentando salto inválido ---");
            var errorCmd = new ChangeStateCommand(candidate, new HiredState(), "Manager");
            auditHistory.ExecuteCommand(errorCmd);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"[Error de Validación] {ex.Message}");
        }

        auditHistory.ShowAuditTrail();


        Console.WriteLine("\n--- Deshaciendo última acción exitosa ---");
        auditHistory.UndoLast();
        Console.WriteLine($"Estado actual tras Undo: {candidate.CurrentState.Name}");
    }
}