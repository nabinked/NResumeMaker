using DbPortal;

namespace ResumeMaker.Data.Models.Core
{
    public sealed class Role : DbEntity
    {
        public Role()
        {
            SchemaName = "core";
            EntityName = "roles";
        }
        public string RoleName { get; set; }
        
    }
}
