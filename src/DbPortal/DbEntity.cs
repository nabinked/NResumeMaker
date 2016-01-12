namespace DbPortal
{
    public abstract class DbEntity
    {

        public long Id { get; set; }
        public virtual string SchemaName { get; set; }
        public virtual string EntityName { get; set; }

        public virtual bool IsNew => Id < 1;
    }
}
