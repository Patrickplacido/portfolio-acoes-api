using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace PortfolioAcoes.Infrastructure.Services
{
    public class EmailSender : IEmailSender<IdentityUser>, IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Implementação de exemplo para envio de e-mails
            Console.WriteLine($"Email para: {email}, Assunto: {subject}, Mensagem: {htmlMessage}");
            return Task.CompletedTask;
        }

        public Task SendConfirmationLinkAsync(IdentityUser user, string email, string confirmationLink)
        {
            return Task.CompletedTask;
        }

        public Task SendPasswordResetLinkAsync(IdentityUser user, string email, string resetLink)
        {
            return Task.CompletedTask;
        }

        public Task SendPasswordResetCodeAsync(IdentityUser user, string email, string resetCode)
        {
            return Task.CompletedTask;
        }
    }
}