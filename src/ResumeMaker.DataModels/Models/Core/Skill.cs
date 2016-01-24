using System.ComponentModel.DataAnnotations;
using DbPortal;

namespace ResumeMaker.Data.Models.Core
{
    public sealed class Skill : DbEntity
    {
        public Skill()
        {
            SchemaName = "core";
            EntityName = "skills";
        }
        public string SkillName { get; set; }
        [Required]
        [Range(1, 5)]
        public int Proficiency { get; set; }
        public long UserId { get; set; }

    }
}
