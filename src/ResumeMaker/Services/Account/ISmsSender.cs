using System.Threading.Tasks;

namespace ResumeMaker.Services.Account
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
