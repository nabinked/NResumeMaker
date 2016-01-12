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
        public long UserId { get; set; }
        public string ObjectiveText { get; set; }
        
    }
}
