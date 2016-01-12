namespace ResumeMaker.Common
{
    public interface IAppUser
    {
        long Id { get; set; }
        string UserName { get; set; }
        string Email { get; set; }

    }
}
