namespace ResumeMaker.Services.Account
{
    public interface IPasswordService
    {
        string CreateHash(string password);
        string CreateRandomPassword(int length);
        bool ValidatePassword(string password, string correctHash);
    }
}