using Reto_1.Entities.DTOs;

namespace Reto_1.Services.NotificationServices
{
    public interface IServiceNotifications
    {
        Task<ResponseDto> SendNotification(string to, string subject, string body);


    }
}
