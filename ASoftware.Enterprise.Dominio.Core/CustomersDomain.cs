using ASoftware.Enterprise.Dominio.Entity;
using ASoftware.Enterprise.Dominio.Interfaz;
using ASoftware.Enterprise.Infraestructura.Interfaz;

namespace ASoftware.Enterprise.Dominio.Core {
    public class CustomersDomain : ICustomersDomain{

        private readonly ICustomersRepository _customersRepository;
        public CustomersDomain(ICustomersRepository customersRepository) {
            _customersRepository = customersRepository;
        }

        public bool Delete(string customerID) {
            return _customersRepository.Delete(customerID);
        }

        public async Task<bool> DeleteAsync(string customerID) {
            return await _customersRepository.DeleteAsync(customerID);
        }

        public Customers Get(string customerID) {
            return _customersRepository.Get(customerID);
        }

        public IEnumerable<Customers> GetAll() {
            return _customersRepository.GetAll();
        }

        public async Task<IEnumerable<Customers>> GetAllAsync() {
            return await _customersRepository.GetAllAsync();
        }

        public async Task<Customers> GetAsync(string customerID) {
            return await _customersRepository.GetAsync(customerID);
        }

        public bool Insert(Customers customer) {
            return _customersRepository.Insert(customer);
        }

        public async Task<bool> InsertAsync(Customers customer) {
            return await _customersRepository.InsertAsync(customer);
        }

        public bool Update(Customers customer) {
            return _customersRepository.Update(customer);
        }

        public async Task<bool> UpdateAsync(Customers customer) {
            return await _customersRepository.UpdateAsync(customer);
        }
    }
}