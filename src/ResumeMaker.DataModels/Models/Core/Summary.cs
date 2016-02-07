using System.ComponentModel.DataAnnotations;
using DbPortal;

namespace ResumeMaker.Data.Models.Core
{
    public class Summary :DbEntity
    {
        public Summary()
        {
            SchemaName = "core";
            EntityName = "summaries";
        }
        [Required]
        public long UserId { get; set; }
        [Required]
        [Display(Name = "Summary")]
        public string SummaryText { get; set; }
        
    }
}
