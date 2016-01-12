using System.ComponentModel.DataAnnotations;
using DbPortal;

namespace ResumeMaker.Data.Models.Core
{
    public class Experience : DbEntity
    {
        public Experience()
        {
            SchemaName = "core";
            EntityName = "experiences";
        }

        public long UserId { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required][Display(Name = "Organization")]
        public string OrganizationName { get; set; }
        [Required][Display(Name = "City")]
        public string OrganizationCity { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string OrganizationCountry { get; set; }

        public string Description { get; set; }
        [Required]
        [Display(Name = "From Year")]
        public int FromYear { get; set; }
        [Required]
        [Display(Name = "To Year")]
        public int ToYear { get; set; }
        [Required]
        public int Duration { get; set; }
    }
}
