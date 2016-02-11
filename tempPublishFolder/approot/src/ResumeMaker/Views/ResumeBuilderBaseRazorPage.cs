using System;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc.Razor;

namespace ResumeMaker.Views
{
    public abstract class ResumeBuilderBaseRazorPage : RazorPage
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        protected ResumeBuilderBaseRazorPage(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected ResumeBuilderBaseRazorPage()
        {
            throw new NotImplementedException();
        }

        public HttpRequest Request => _httpContextAccessor.HttpContext.Request;

        public long UserId { get; set; }

    }
}
