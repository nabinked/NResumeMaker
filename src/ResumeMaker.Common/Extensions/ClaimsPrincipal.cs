using System.Security.Claims;

namespace ResumeMaker.Common.Extensions
{
    public static class ClaimsPrincipal
    {
        public static string GetName(this System.Security.Claims.ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal.FindClaim(ClaimTypes.Name);
            return claim?.Value;
        }

        private static Claim FindClaim(this System.Security.Claims.ClaimsPrincipal claimsPrincipal, string httpSchemasXmlsoapOrgWsIdentityClaimsName)
        {
            return ((ClaimsIdentity)claimsPrincipal.Identity).FindFirst(httpSchemasXmlsoapOrgWsIdentityClaimsName);
        }

        public static long GetId(this System.Security.Claims.ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal.FindClaim(ClaimTypes.Sid);
            return claim?.Value.ToLong() ?? 0;
        }
        public static string GetEmail(this System.Security.Claims.ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal.FindClaim(ClaimTypes.Email);
            return claim?.Value;
        }
        public static string GetPublicProfile(this System.Security.Claims.ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal.FindClaim("public_profile");
            return claim?.Value;
        }
    }
}
