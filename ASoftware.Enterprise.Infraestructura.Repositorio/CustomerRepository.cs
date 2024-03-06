using ASoftware.Enterprise.Dominio.Entity;
using ASoftware.Enterprise.Infraestructura.Interfaz;
using ASoftware.Enterprise.Transversal.Common;
using Dapper;
using System.Data;

namespace ASoftware.Enterprise.Infraestructura.Repositorio {
    public class CustomerRepository : ICustomersRepository {
        
        private readonly IConnectionFactory connectionFactory;
        public CustomerRepository(IConnectionFactory connectionFactory) {
            this.connectionFactory = connectionFactory;
        }

        public bool Delete(string customerID) {
            using (var connection = connectionFactory.GetConnection) {
                var storedProcedure = "CustomersDelete";
                var parametros = new DynamicParameters();
                parametros.Add("CustomerID", customerID);

                var result = connection.Execute(storedProcedure, param: parametros, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(string customerID) {
            using (var connection = connectionFactory.GetConnection) {
                var storedProcedure = "CustomersDelete";
                var parametros = new DynamicParameters();
                parametros.Add("CustomerID", customerID);

                var result = await connection.ExecuteAsync(storedProcedure, param: parametros, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public Customers Get(string customerID) {
            using (var connection = connectionFactory.GetConnection) {
                var storedProcedure = "CustomersGetByID";
                var parametros = new DynamicParameters();
                parametros.Add("CustomerID", customerID);

                var customer = connection.QuerySingle<Customers>(storedProcedure, param: parametros, commandType: CommandType.StoredProcedure);

                return customer;
            }
        }

        public IEnumerable<Customers> GetAll() {
            using (var connection = connectionFactory.GetConnection) {
                var storedProcedure = "CustomersList";

                var customers = connection.Query<Customers>(storedProcedure, commandType: CommandType.StoredProcedure);

                return customers;
            }
        }

        public async Task<IEnumerable<Customers>> GetAllAsync() {
            using (var connection = connectionFactory.GetConnection) {
                var storedProcedure = "CustomersList";

                var customers = await connection.QueryAsync<Customers>(storedProcedure, commandType: CommandType.StoredProcedure);

                return customers;
            }
        }

        public async Task<Customers> GetAsync(string customerID) {
            using (var connection = connectionFactory.GetConnection) {
                var storedProcedure = "CustomersGetByID";
                var parametros = new DynamicParameters();
                parametros.Add("CustomerID", customerID);

                var customer = await connection.QuerySingleAsync<Customers>(storedProcedure, param: parametros, commandType: CommandType.StoredProcedure);

                return customer;
            }
        }

        public bool Insert(Customers customer) {
            using(var connection = connectionFactory.GetConnection) {
                var storedProcedure = "CustomersInsert";
                var parametros = new DynamicParameters();
                parametros.Add("CustomerID", customer.CustomerID);
                parametros.Add("CompanyName", customer.CompanyName);
                parametros.Add("ContactName", customer.ContactName);
                parametros.Add("ContactTitle", customer.ContactTitle);
                parametros.Add("Address", customer.Address);
                parametros.Add("City", customer.City);
                parametros.Add("Region", customer.Region);
                parametros.Add("PostalCode",customer.PostalCode);
                parametros.Add("Country", customer.Country);
                parametros.Add("Phone", customer.Phone);
                parametros.Add("Fax", customer.Fax);

                var result = connection.Execute(storedProcedure, param:parametros, commandType:CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public async Task<bool> InsertAsync(Customers customer) {
            using (var connection = connectionFactory.GetConnection) {
                var storedProcedure = "CustomersInsert";
                var parametros = new DynamicParameters();
                parametros.Add("CustomerID", customer.CustomerID);
                parametros.Add("CompanyName", customer.CompanyName);
                parametros.Add("ContactName", customer.ContactName);
                parametros.Add("ContactTitle", customer.ContactTitle);
                parametros.Add("Address", customer.Address);
                parametros.Add("City", customer.City);
                parametros.Add("Region", customer.Region);
                parametros.Add("PostalCode", customer.PostalCode);
                parametros.Add("Country", customer.Country);
                parametros.Add("Phone", customer.Phone);
                parametros.Add("Fax", customer.Fax);

                var result = await connection.ExecuteAsync(storedProcedure, param: parametros, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public bool Update(Customers customer) {
            using (var connection = connectionFactory.GetConnection) {
                var storedProcedure = "CustomersUpdate";
                var parametros = new DynamicParameters();
                parametros.Add("CustomerID", customer.CustomerID);
                parametros.Add("CompanyName", customer.CompanyName);
                parametros.Add("ContactName", customer.ContactName);
                parametros.Add("ContactTitle", customer.ContactTitle);
                parametros.Add("Address", customer.Address);
                parametros.Add("City", customer.City);
                parametros.Add("Region", customer.Region);
                parametros.Add("PostalCode", customer.PostalCode);
                parametros.Add("Country", customer.Country);
                parametros.Add("Phone", customer.Phone);
                parametros.Add("Fax", customer.Fax);

                var result = connection.Execute(storedProcedure, param: parametros, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Customers customer) {
            using (var connection = connectionFactory.GetConnection) {
                var storedProcedure = "CustomersUpdate";
                var parametros = new DynamicParameters();
                parametros.Add("CustomerID", customer.CustomerID);
                parametros.Add("CompanyName", customer.CompanyName);
                parametros.Add("ContactName", customer.ContactName);
                parametros.Add("ContactTitle", customer.ContactTitle);
                parametros.Add("Address", customer.Address);
                parametros.Add("City", customer.City);
                parametros.Add("Region", customer.Region);
                parametros.Add("PostalCode", customer.PostalCode);
                parametros.Add("Country", customer.Country);
                parametros.Add("Phone", customer.Phone);
                parametros.Add("Fax", customer.Fax);

                var result = await connection.ExecuteAsync(storedProcedure, param: parametros, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }
    }
}