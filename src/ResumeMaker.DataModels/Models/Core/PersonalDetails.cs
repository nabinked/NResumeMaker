using System;
using DbPortal;

namespace ResumeMaker.Data.Models.Core
{
    public class PersonalDetails : DbEntity
    {
        public PersonalDetails()
        {
            SchemaName = "core";
            EntityName = "personal_details";
        }

        public long UserId { get; set; }    
        public DateTime DateofBirth { get; set; }
        public int GenderId { get; set; }
        public string DriverLicenceId { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string LanguagesSpoken { get; set; }
        
    }
}
