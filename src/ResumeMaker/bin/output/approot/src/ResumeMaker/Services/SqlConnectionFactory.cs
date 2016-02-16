using DbPortal;
using Microsoft.Extensions.OptionsModel;
using ResumeMaker.Common;

namespace ResumeMaker.Services
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        public SqlConnectionFactory(IOptions<Appsettings> appSettings)
        {
            ConnectionString = appSettings.Value.ConnectionString;

        }

        public string ConnectionString { get; }
    }
}
