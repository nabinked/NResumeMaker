using System.Collections.Generic;
using System.Linq;
using DbPortal;

namespace ResumeMaker.Data.Models.Core
{
    public class DriverLicence : DbEntity
    {
        public DriverLicence()
        {
            SchemaName = "core";
            EntityName = "driver_licences";
        }

        public string LicenceType { get; set; }
      //  public static IEnumerable<SelectListItem> DriverLicenceTypes => new DbTransactions<DriverLicence>().GetAll().Select(x=>x.LicenceType);

    }
}
