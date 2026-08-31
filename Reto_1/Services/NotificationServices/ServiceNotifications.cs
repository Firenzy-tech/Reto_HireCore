using System;
using Reto_1.Entities.DTOs;

namespace Reto_1.Services.NotificationServices
{
    public class ServiceNotifications : IServiceNotifications
    {
        public Task<ResponseDto> SendNotification(string to, string subject, string body)
        {
            Console.WriteLine($"    [{subject}] -> {to}: {body}");

            return Task.FromResult(new ResponseDto
            {
                Success = true,
                Message = $"Notificación enviada a {to}"
            });
        }
    }
}
