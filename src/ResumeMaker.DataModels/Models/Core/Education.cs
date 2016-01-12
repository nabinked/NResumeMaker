using System.ComponentModel.DataAnnotations;
using DbPortal;

namespace ResumeMaker.Data.Models.Core
{
    public class Education : DbEntity
    {
        public Education()
        {
            SchemaName = "core";
            EntityName = "educations";
        }
        [Required]
        public long UserId { get; set; }
        [Required] [Display(Name = "Year of Completion")]
        public int YearOfCompletion { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string School { get; set; }
        [Required]
        [Display(Name = "Education Degree")]
        public string EducationDegree { get; set; }
    }
}
