using System.Threading.Tasks;

    namespace ResumeMaker.Services.Account
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
