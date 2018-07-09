using System.Data.SqlClient;
using KrisTestBank.Core.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;


namespace KrisTestBank.Core.Repositories
{
    public class ConnectionRepository : IConnectionRepository
    {
        private static SqlConnection _connection;
        private readonly IConfiguration _configuration;

        public ConnectionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection Connection {
            get
            {
                if (_connection == null)
                {
                    var connectionString = _configuration.GetSection("ConnectionStrings").GetSection("SQL").Value;

                    _connection = new SqlConnection(connectionString);
                }

                return _connection;
            }
        }
    }
}
