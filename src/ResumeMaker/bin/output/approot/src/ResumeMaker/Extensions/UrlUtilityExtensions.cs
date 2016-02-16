using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeMaker.Extensions
{
    public static class UrlUtilityExtensions
    {
        public static bool IsStringValidUrl(this string urlString)
        {
            if (string.IsNullOrWhiteSpace(urlString)) return false;

            Uri uriResult;
            return Uri.TryCreate(urlString, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

        }
    }
}
