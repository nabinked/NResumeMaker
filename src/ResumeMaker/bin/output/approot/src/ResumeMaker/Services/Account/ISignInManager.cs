using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using ResumeMaker.Common;

namespace ResumeMaker.Services.Account
{
    public interface ISignInManager
    {
        HttpContext Context { get; set; }
        Task SignInAsync(IAppUser user);
        Task LogOutAsync();
        Task<ClaimsPrincipal> GetExternalIdentity(string authenticationScheme);
    }
}
