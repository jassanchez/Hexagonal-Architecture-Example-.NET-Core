using ASoftware.Enterprise.Dominio.Entity;

namespace ASoftware.Enterprise.Dominio.Interfaz {
    public interface ICustomersDomain {
        bool Insert(Customers customer);
        bool Update(Customers customer);
        bool Delete(string customerID);
        Customers Get(string customerID);
        IEnumerable<Customers> GetAll();


        Task<bool> InsertAsync(Customers customer);
        Task<bool> UpdateAsync(Customers customer);
        Task<bool> DeleteAsync(string customerID);
        Task<Customers> GetAsync(string customerID);
        Task<IEnumerable<Customers>> GetAllAsync();
    }
}
