using Microsoft.AspNet.Http;

namespace ResumeMaker.Services
{
    public class ResumeBuilderViewHelper : IResumeBuilderViewHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ResumeBuilderViewHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string CurrentUrl => GetCurrentUrl();

        public HttpRequest Request => _httpContextAccessor.HttpContext.Request;

        private string GetCurrentUrl()
        {
            return Request.Scheme + "://" + Request.Host + Request.Path;
        }
    }
}
