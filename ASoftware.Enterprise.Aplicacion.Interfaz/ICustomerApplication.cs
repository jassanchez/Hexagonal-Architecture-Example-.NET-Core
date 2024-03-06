using ASoftware.Enterprise.Aplicacion.DTO;
using ASoftware.Enterprise.Transversal.Common;

namespace ASoftware.Enterprise.Aplicacion.Interfaz {
    public interface ICustomerApplication {
        Response<bool> Insert(CustomersDTO customer);
        Response<bool> Update(CustomersDTO customer);
        Response<bool> Delete(string customerID);
        Response<CustomersDTO> Get(string customerID);
        Response<IEnumerable<CustomersDTO>> GetAll();


        Task<Response<bool>> InsertAsync(CustomersDTO customer);
        Task<Response<bool>> UpdateAsync(CustomersDTO customer);
        Task<Response<bool>> DeleteAsync(string customerID);
        Task<Response<CustomersDTO>> GetAsync(string customerID);
        Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync();
    }
}