using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DbPortal;

namespace ResumeMaker.Data.Models.Core
{
    public class ContactDetail : DbEntity
    {
        public ContactDetail()
        {
            SchemaName = "core";
            EntityName = "contact_details";
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
        public long UserId { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name="Street Address")]
        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string Suburb { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }

        [Display(Name = "Telephone")]
        public string TelephoneNum { get; set; }
        [Required]
        public string MobileNum { get; set; }

        [Display(Name = "GitHub Url")]
        public string GithubUrl { get; set; }
        [Display(Name = "Facebook Url")]
        public string FacebookUrl { get; set; }
        [Display(Name = "LinkedIn Url")]
        public string LinkedinUrl { get; set; }
        [Display(Name = "Twitter Url")]
        public string TwitterUrl { get; set; }

    }
}
