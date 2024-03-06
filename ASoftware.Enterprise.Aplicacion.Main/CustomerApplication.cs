using ASoftware.Enterprise.Aplicacion.DTO;
using ASoftware.Enterprise.Aplicacion.Interfaz;
using ASoftware.Enterprise.Dominio.Entity;
using ASoftware.Enterprise.Dominio.Interfaz;
using ASoftware.Enterprise.Transversal.Common;
using AutoMapper;

namespace ASoftware.Enterprise.Aplicacion.Main {
    public class CustomerApplication : ICustomerApplication{
        private readonly ICustomersDomain _customersDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomerApplication> _logger;

        public CustomerApplication(ICustomersDomain customersDomain, IMapper mapper, IAppLogger<CustomerApplication> logger) {
            _customersDomain = customersDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public Response<bool> Delete(string customerID) {
            var response = new Response<bool>();
            try {
                response.IsSuccess = response.Data = _customersDomain.Delete(customerID);
                response.Message = "Eliminacion exitosa";
            } catch (Exception e) {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(string customerID) {
            var response = new Response<bool>();
            try {
                response.IsSuccess = response.Data = await _customersDomain.DeleteAsync(customerID);
                response.Message = "Eliminacion exitosa";
            } catch (Exception e) {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<CustomersDTO> Get(string customerID) {
            var response = new Response<CustomersDTO>();
            try {
                var customer = _customersDomain.Get(customerID);
                response.Data = _mapper.Map<CustomersDTO>(customer);
                if (response.Data != null) {
                    response.Message = "Consulta OK";
                    response.IsSuccess = true;
                }

            } catch (Exception e) {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<IEnumerable<CustomersDTO>> GetAll() {
            var response = new Response<IEnumerable<CustomersDTO>>();
            try {
                var customer = _customersDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customer);
                if (response.Data != null) {
                    response.Message = "Consulta OK";
                    response.IsSuccess = true;
                    _logger.LogInfo("Consulta Exitosa GetAll()");
                }

            } catch (Exception e) {
                response.Message = e.Message;
                _logger.LogError("Customers.GetAll() Exception: " + e.Message);
            }
            return response;
        }

        public async Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync() {
            var response = new Response<IEnumerable<CustomersDTO>>();
            try {
                var customer = await _customersDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customer);
                if (response.Data != null) {
                    response.Message = "Consulta OK";
                    response.IsSuccess = true;
                }

            } catch (Exception e) {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<CustomersDTO>> GetAsync(string customerID) {
            var response = new Response<CustomersDTO>();
            try {
                var customer = await _customersDomain.GetAsync(customerID);
                response.Data = _mapper.Map<CustomersDTO>(customer);
                if(response.Data == null)
                    response.Message = "Sin informacion";
                else
                    response.Message = "Consulta exitosa";

            } catch (Exception e) {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Insert(CustomersDTO customer) {
            var response = new Response<bool>();
            try {
                var customers = _mapper.Map<Customers>(customer);
                response.IsSuccess = response.Data = _customersDomain.Insert(customers);
                response.Message = "Registro exitoso";
            } catch (Exception e) {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> InsertAsync(CustomersDTO customer) {
            var response = new Response<bool>();
            try {
                var customers = _mapper.Map<Customers>(customer);
                response.IsSuccess = response.Data = await _customersDomain.InsertAsync(customers);
                response.Message = "Registro exitoso";
            } catch (Exception e) {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Update(CustomersDTO customer) {
            var response = new Response<bool>();
            try {
                var customers = _mapper.Map<Customers>(customer);
                response.IsSuccess = response.Data = _customersDomain.Update(customers);
                response.Message = "Actualizacion exitosa";
            } catch (Exception e) {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(CustomersDTO customer) {
            var response = new Response<bool>();
            try {
                var customers = _mapper.Map<Customers>(customer);
                response.IsSuccess = response.Data = await _customersDomain.UpdateAsync(customers);
                response.Message = "Actualizacion exitosa";
            } catch (Exception e) {
                response.Message = e.Message;
            }
            return response;
        }
    }
}