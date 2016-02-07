using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;
using ResumeMaker.Data.Models.Core;

namespace ResumeMaker.Extensions.ModelExtension
{
    public static class ContactDetailsExtensions
    {
        public static HtmlString GetFullAddress(this ContactDetail contactDetail)
        {
            var address = "";
            if (!string.IsNullOrWhiteSpace(contactDetail.StreetAddress))
            {
                address += $"{contactDetail.StreetAddress} <br />";
            }
            if (!string.IsNullOrWhiteSpace(contactDetail.Suburb))
            {
                address += $"{contactDetail.Suburb}";
            }
            if (!string.IsNullOrWhiteSpace(contactDetail.State))
            {
                address += $", {contactDetail.State}";
            }
            if (!string.IsNullOrWhiteSpace(contactDetail.Country))
            {
                address += $", {contactDetail.Country} <br />";
            }
            return new HtmlString(address);
        }

        
    }
}
