using Microsoft.Extensions.OptionsModel;
using ResumeMaker.Common;

namespace ResumeMaker.Services
{
    public class ImageHelper : IImageHelper
    {
        private readonly Appsettings _appsetings;

        public ImageHelper(IOptions<Appsettings> appsettingsOptions )
        {
            _appsetings = appsettingsOptions.Value;
        }
        public string GetImageUrl(long userId)
        {
            var url = _appsetings.DefaultImage;
            return url;
        }
    }
}
