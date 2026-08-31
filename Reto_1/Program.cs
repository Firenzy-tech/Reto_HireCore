using Microsoft.Extensions.DependencyInjection;
using Reto_1.Entities;
using Reto_1.Entities.DTOs;
using Reto_1.Services.Commands;
using Reto_1.Services.HireServices;
using Reto_1.Services.NotificationServices;
using Reto_1.Services.Observers;

namespace Reto_1
{
    public class Program
    {
        private readonly IHireService _hireService;

        public Program(IHireService hireService)
        {
            _hireService = hireService;
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IServiceNotifications, ServiceNotifications>();
            serviceCollection.AddSingleton<ICommandHistory, CommandHistory>();
            serviceCollection.AddSingleton<IHireObserver, RecruiterObserver>();
            serviceCollection.AddSingleton<IHireObserver, HiringManagerObserver>();
            serviceCollection.AddSingleton<IHireObserver, PayrollObserver>();
            serviceCollection.AddSingleton<IHireObserver, CandidatePortalObserver>();
            serviceCollection.AddSingleton<IHireService, HireService>();
            serviceCollection.AddTransient<Program>();
            return serviceCollection.BuildServiceProvider();
        }

        public static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var serviceProvider = ConfigureServices();
            var program = serviceProvider.GetRequiredService<Program>();

            await program.Run();
        }

        private async Task Run()
        {
            Print(await _hireService.ChangeStatus("CC", "123456789", HireStatus.STATUS_ENTREVISTA, "laura.gomez"));
            Print(await _hireService.ChangeStatus("CC", "123456789", HireStatus.STATUS_CONTRATADO, "laura.gomez"));
            Print(await _hireService.ChangeStatus("CC", "123456789", HireStatus.STATUS_OFERTA, "laura.gomez"));
            Print(await _hireService.ChangeStatus("CC", "123456789", HireStatus.STATUS_RECHAZADO, "carlos.ruiz"));
            Print(await _hireService.Undo("carlos.ruiz"));
            Print(await _hireService.ChangeStatus("CC", "123456789", HireStatus.STATUS_CONTRATADO, "laura.gomez"));

            Console.WriteLine("AUDITORÍA");

            foreach (var entry in _hireService.AuditTrail())
            {
                var undone = entry.UndoneBy == null
                    ? string.Empty
                    : $" | deshecho por {entry.UndoneBy} el {entry.UndoneAt}";

                Console.WriteLine($"{entry.ExecutedAt} | {entry.ExecutedBy} | {entry.Description}{undone}");
            }
        }

        private static void Print(ResponseDto response)
        {
            Console.WriteLine($"{(response.Success ? "OK" : "ERROR")}: {response.Message}");
            Console.WriteLine();
        }
    }
}
