using Microsoft.AspNet.Http;

namespace ResumeMaker.Services
{
    public interface IResumeBuilderViewHelper
    {
        string CurrentUrl { get; }
    }
}
