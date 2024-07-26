using DesafioDiaDoRock.ApplicationCore.Entities;
using DesafioDiaDoRock.ApplicationCore.Interfaces.Repositories;
using DesafioDiaDoRock.ApplicationCore.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace DesafioDiaDoRock.ApplicationCore.Services
{
    public class EmailService(HttpClient httpClient, IConfiguration config, IUserRepository userRepository) : IEmailService
    {
        private readonly HttpClient _client = httpClient;
        private readonly IConfiguration _config = config;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task SendEmailForAlUser(Event @event)
        {
            List<User> users = await _userRepository.GetListUsers();


            foreach(User user in users)
            {
                await SendSendblue(user, 

                    $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n" +
                    $"    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\"" +
                    $" content=\"width=device-width, initial-scale=1.0\">\r\n</head>\r\n<body style=\"font-family: Arial, sans-serif; line-height: 1.6; margin: 0; padding: 0;" +
                    $" background-color: #f4f4f4; color: #333;\">\r\n    <div style=\"max-width: 600px; margin: 20px auto; background: #fff; padding: 20px; border-radius: 10px;" +
                    $" box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\">\r\n        <h1 style=\"color: #444;\">Novo Evento na Link Parse!</h1>\r\n " +
                    $"       <p>Olá {user.Name},</p>\r\n        <p>Temos o prazer de anunciar um novo evento adicionado na Link Parse. Venha fazer parte da festa e garanta já o seu ingresso!</p>\r\n" +
                    $"        <h2 style=\"color: #444;\">Detalhes do Evento</h2>\r\n        <ul style=\"list-style-type: none; padding: 0;\">\r\n           " +
                    $" <li><strong>Nome da Banda:</strong>{@event.Band} </li>\r\n            <li><strong>Local:</strong> {@event.NameLocation}</li>\r\n           " +
                    $" <li><strong>Data:</strong> {@event.Date}</li>\r\n\r\n        </ul>\r\n        <p>Não perca essa oportunidade incrível de se divertir com a gente!</p>\r\n " +
                    $"       <a href=\"https://link-parse-eventos.com/ingressos\" style=\"display: inline-block; padding: 10px 20px; margin-top: 20px; border-radius: 5px; background: #007BFF; " +
                    $"color: white; text-decoration: none; font-size: 16px;\">Garanta seu Ingresso</a>\r\n        <div style=\"text-align: center; margin-top: 20px; font-size: 12px; color: #666;\">\r\n            " +
                    $"<p>&copy; 2024 Link Parse. Todos os direitos reservados.</p>\r\n            " +
                    $"<p><a href=\"https://link-parse-eventos.com/politica-privacidade\" style=\"color: #007BFF; text-decoration: none;\">Política de Privacidade</a> | <a href=\"https://link-parse-eventos.com/termos-uso\" style=\"color: #007BFF; text-decoration: none;\">Termos de Uso</a></p>\r\n       " +
                    $" </div>\r\n    </div>\r\n</body>\r\n</html>",

                   "Novo Evento Disponível na Link Parse" );
            }
            
        }
        public async Task<bool> SendSendblue(User user, string body, string assunto)
        {
            var requestBody = new RequestSendblue
            {
                subject = assunto,
                htmlContent = body,
                sender = new Sender
                {
                    email = "raphaelfranciscodev@gmail.com",
                    name =  "Link Parse Group"
                },

                to = new List<Recipient>()
                {
                    new ()
                    {
                        email = user.Email,
                        name = user.Name
                    }
                }
            };

            var jsonContent = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://api.brevo.com/v3/smtp/email");
            requestMessage.Headers.Add("accept", "application/json");
            requestMessage.Headers.Add("api-key", /*Configuration.ApiKeySendblue*/);
            requestMessage.Content = content;

            var response = await _client.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro ao enviar o email: {errorMessage}");
            }

            return true;
        }
    }

    public class RequestSendblue
    {
        public string subject { get; set; }
        public string htmlContent { get; set; }
        public Sender sender { get; set; }
        public List<Recipient> to { get; set; }
    }

    public class Sender
    {
        public string email { get; set; }
        public string name { get; set; }
    }

    public class Recipient
    {
        public string email { get; set; }
        public string name { get; set; }
    }
}
