using ASoftware.Enterprise.Transversal.Common;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ASoftware.Enterprise.Infraestructura {
    public class ConnectionFactory : IConnectionFactory {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration) {
            _configuration = configuration;
        }

        public IDbConnection GetConnection {
            get {
                SqlConnection sqlConnection = new SqlConnection();
                if (sqlConnection == null) return null;

                sqlConnection.ConnectionString = _configuration.GetConnectionString("NorthwindConnection");
                sqlConnection.Open();

                return sqlConnection;
            }
        }
    }
}