using HireCore.ConsoleApp.Command;
using HireCore.ConsoleApp.Domain;
using HireCore.ConsoleApp.Helpers;
using HireCore.ConsoleApp.Observer;
using HireCore.ConsoleApp.State;

class Program
{
    static void Main()
    {
        var auditHistory = new AuditHistory();
        var notificationManager = new NotificationManager();

        notificationManager.Subscribe(new RecruiterNotifier());
        notificationManager.Subscribe(new HiringManagerNotifier());
        notificationManager.Subscribe(new PayrollNotifier());
        notificationManager.Subscribe(new CandidatePortalNotifier());

        var manager = new CandidateManager(auditHistory, notificationManager);
        var candidate = new Candidate("Carlos Escobar");
        string currentUser = NameHelper.GetRandom();

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n=================================================");
            Console.WriteLine($"Candidato: {candidate.Name} | Estado Actual: [{candidate.CurrentState.Name}]");
            Console.WriteLine("=================================================");
            Console.WriteLine("Seleccione una acción:");
            Console.WriteLine("1. Avanzar a INTERVIEW (Entrevista)");
            Console.WriteLine("2. Avanzar a TECHNICAL_TEST (Prueba Técnica)");
            Console.WriteLine("3. Avanzar a OFFER (Oferta)");
            Console.WriteLine("4. Avanzar a REFERENCE_CHECK (Referencias)");
            Console.WriteLine("5. Avanzar a HIRED (Contratado)");
            Console.WriteLine("6. Cambiar a REJECTED (Rechazado)");
            Console.WriteLine("7. Deshacer última acción (Undo)");
            Console.WriteLine("8. Ver Historial de Auditoría");
            Console.WriteLine("9. Salir");
            Console.Write("\nOpción: ");

            string? choice = Console.ReadLine();
            Console.WriteLine(); 

            try
            {
                switch (choice)
                {
                    case "1":
                        manager.AdvanceState(candidate, new InterviewState(), currentUser);
                        break;
                    case "2":
                        manager.AdvanceState(candidate, new TechnicalTestState(), currentUser);
                        break;
                    case "3":
                        manager.AdvanceState(candidate, new OfferState(), currentUser);
                        break;
                    case "4":
                        manager.AdvanceState(candidate, new ReferenceCheckState(), currentUser);
                        break;
                    case "5":
                        manager.AdvanceState(candidate, new HiredState(), currentUser);
                        break;
                    case "6":
                        manager.AdvanceState(candidate, new RejectedState(), currentUser);
                        break;
                    case "7":
                        auditHistory.UndoLast();
                        break;
                    case "8":
                        auditHistory.ShowAuditTrail();
                        break;
                    case "9":
                        exit = true;
                        Console.WriteLine("Saliendo del sistema HireCore...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ERROR DE NEGOCIO] {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}