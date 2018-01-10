using System.Threading.Tasks;

namespace GuildManager.Simulator.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
