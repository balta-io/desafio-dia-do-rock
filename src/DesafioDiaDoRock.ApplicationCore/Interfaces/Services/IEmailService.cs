using DesafioDiaDoRock.ApplicationCore.Entities;
using DesafioDiaDoRock.ApplicationCore.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDiaDoRock.ApplicationCore.Interfaces.Services
{
    public interface IEmailService
    {
        Task<bool> SendSendblue(User user, String body, String assunto);
        Task SendEmailForAlUser(Event @event);
    }
}
