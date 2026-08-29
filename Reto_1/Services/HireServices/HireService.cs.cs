using MyApp.Models;
using Reto_1.Entities.DTOs;
using Reto_1.Services.NotificationServices;

namespace Reto_1.Services.HireServices
{
    public class HireService : IHireService
    {

        private readonly IServiceNotifications _serviceNotifications;

        public HireService(IServiceNotifications serviceNotifications)
        {
            _serviceNotifications = serviceNotifications;
        }
        private readonly List<Person> _person = new(); // O inyecta un repositorio

        public async Task<ResponseDto> ChangeStatus(string documentType, string documentNumber, string newStatus)
        {
            var candidato = _person.FirstOrDefault(c =>
                c.TipoDocumento == documentType && c.NumeroDocumento == documentNumber);

            if (candidato == null)
            {
                return new ResponseDto
                {
                    Success = false,
                    Message = "Candidato no encontrado"
                };
            }

            try
            {
                if (candidato.Estado == "APLICADO" && newStatus == "ENTREVISTA")
                {
                    candidato.Estado = "ENTREVISTA";
                    await _serviceNotifications.SendNotification(candidato.ReclutadorEmail, $"{candidato.Nombre} pasó a entrevista");
                }
                else if (candidato.Estado == "ENTREVISTA" && newStatus == "OFERTA")
                {
                    candidato.Estado = "OFERTA";
                    await _serviceNotifications.SendNotification(candidato.ReclutadorEmail, $"Oferta enviada a {candidato.Nombre}");
                }
                else if (candidato.Estado == "OFERTA" && newStatus == "CONTRATADO")
                {
                    candidato.Estado = "CONTRATADO";
                    await _serviceNotifications.SendNotification(candidato.ReclutadorEmail, $"{candidato.Nombre} fue contratado");
                }
                else if (newStatus == "RECHAZADO")
                {
                    candidato.Estado = "RECHAZADO";
                    await _serviceNotifications.SendNotification(candidato.ReclutadorEmail, $"{candidato.Nombre} fue rechazado");
                }
                else
                {
                    return new ResponseDto
                    {
                        Success = false,
                        Message = $"Transición inválida: {candidato.Estado} -> {newStatus}"
                    };
                }

                return new ResponseDto
                {
                    Success = true,
                    Message = $"Estado cambiado a {newStatus}"
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}