using System.ComponentModel.DataAnnotations;
using DbPortal;

namespace ResumeMaker.Data.Models.Core
{
    public class ContactDetails : DbEntity
    {
        public ContactDetails()
        {
            SchemaName = "core";
            EntityName = "contact_details";
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string TelephoneNum { get; set; }
        [Required]
        public string MobileNum { get; set; }
        public string GithubUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string TwitterUrl { get; set; }

    }
}
