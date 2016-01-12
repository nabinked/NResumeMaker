using System.ComponentModel.DataAnnotations;
using DbPortal;

namespace ResumeMaker.Data.Models.Core
{
    public class JobDescription : DbEntity
    {
        public JobDescription()
        {
            SchemaName = "core";
            EntityName = "job_descriptions";
        }

        public long ExperienceId { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
