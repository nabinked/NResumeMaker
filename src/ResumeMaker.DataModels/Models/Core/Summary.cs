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
        public long UserId { get; set; }
        public string SummaryText { get; set; }
        
    }
}
