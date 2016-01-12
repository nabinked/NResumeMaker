using System.ComponentModel.DataAnnotations;
using DbPortal;

namespace ResumeMaker.Data.Models.Core
{
    public class KeyAccomplishment : DbEntity
    {
        public KeyAccomplishment()
        {
            SchemaName = "core";
            EntityName = "key_accomplishments";
        }

        public long ExperienceId { get; set; }
        [Required]
        public string Accomplishment { get; set; }
    }
}
