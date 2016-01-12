using DbPortal;

namespace ResumeMaker.Data.Models.Core
{
    public sealed class User : DbEntity
    {
        public User()
        {
            SchemaName = "core";
            EntityName = "users";
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        
    }
}
