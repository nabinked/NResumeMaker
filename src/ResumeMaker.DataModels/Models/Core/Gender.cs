using DbPortal;

namespace ResumeMaker.Data.Models.Core
{
    public sealed class Gender : DbEntity
    {
        public Gender()
        {
            SchemaName = "core";
            EntityName = "genders";
        }
        public Gender(long id) : this()
        {
            Id = id;
        }
        public string GenderName { get; set; }

    }
}
