using Microsoft.Extensions.DependencyInjection;
using Reto_1.Entities;
using Reto_1.Entities.DTOs;
using Reto_1.Services.HireServices;

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
            serviceCollection.AddTransient<IHireService, HireService>();
            serviceCollection.AddTransient<Program>();
            return serviceCollection.BuildServiceProvider();
        }

        public static async Task Main(string[] args)
        {
           
            var serviceProvider = ConfigureServices();
            var program = serviceProvider.GetRequiredService<Program>();

            var data = await program._hireService.ChangeStatus("CC", "123456789", HireStatus.STATUS_ENTREVISTA);
           
        }

 

        public void ChangeStatus(Candidato candidato, string nuevoEstado)
        {
            if (candidato.Estado == STATUS_APLICADO && nuevoEstado == STATUS_ENTREVISTA)
            {
                candidato.Estado = STATUS_ENTREVISTA;
                EmailService.Enviar(candidato.ReclutadorEmail, $"{candidato.Nombre} pasó a entrevista");
            }
            else if (candidato.Estado == STATUS_ENTREVISTA && nuevoEstado == STATUS_OFERTA)
            {
                candidato.Estado = STATUS_OFERTA;
                EmailService.Enviar(candidato.ReclutadorEmail, $"Oferta enviada a {candidato.Nombre}");
            }
            else if (candidato.Estado == STATUS_OFERTA && nuevoEstado == STATUS_CONTRATADO)
            {
                candidato.Estado = STATUS_CONTRATADO;
                EmailService.Enviar(candidato.ReclutadorEmail, $"{candidato.Nombre} fue contratado");
            }
            else if (nuevoEstado == STATUS_RECHAZADO)
            {
                candidato.Estado = STATUS_RECHAZADO;
                EmailService.Enviar(candidato.ReclutadorEmail, $"{candidato.Nombre} fue rechazado");
            }
            else
            {
                throw new Exception($"Transición inválida: {candidato.Estado} -> {nuevoEstado}");
            }
        }

       
    }
}












