using System.ComponentModel.DataAnnotations;
using DbPortal;

namespace ResumeMaker.Data.Models.Core
{
    public class Objective :DbEntity
    {
        public Objective()
        {
            SchemaName = "core";
            EntityName = "objectives";
        }
        [Required]
        public long UserId { get; set; }
        [Required]
        [Display(Name = "Objective")]
        public string ObjectiveText { get; set; }
        
    }
}
