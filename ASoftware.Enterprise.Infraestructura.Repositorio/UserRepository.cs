using ASoftware.Enterprise.Dominio.Entity;
using ASoftware.Enterprise.Infraestructura.Interfaz;
using ASoftware.Enterprise.Transversal.Common;
using Dapper;
using System.Data;

namespace ASoftware.Enterprise.Infraestructura.Repositorio {
    public class UserRepository : IUserRepository {

        private readonly IConnectionFactory _connextionFactory;
        public UserRepository(IConnectionFactory connextionFactory) {
            _connextionFactory = connextionFactory;
        }

        public Users Authenticate(string username, string password) {
            using (var connection = _connextionFactory.GetConnection) {
                string query = "UsersGetByUserAndPassword";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserName", username);
                parameters.Add("Password", password);

                var user = connection.QuerySingle<Users>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return user;
            }
        }

    }
}
