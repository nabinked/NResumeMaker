using DbPortal;
using ResumeMaker.Common;
using ResumeMaker.Data;

namespace ResumeMaker.Services.Account
{
    public class User
    {
        private readonly string _connectionString;

        public User(
        IConnectionFactory connectionFactory)
        {
            _connectionString = connectionFactory.ConnectionString;
        }

        public Data.Models.Core.User GetUserById(long id)
        {
            return new DbContext().User.Get(id);
        }

        public Data.Models.Core.User GetUserByEmail(string email)
        {
            return new DbContext().User.Find(o => o.Email, email);
        }

        public long CreateUserReturningId(Data.Models.Core.User dbUser)
        {
            return new DbContext().User.Create(dbUser);
        }

    }
}
