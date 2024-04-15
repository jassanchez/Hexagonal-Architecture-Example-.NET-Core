using ASoftware.Enterprise.Aplicacion.DTO;
using ASoftware.Enterprise.Aplicacion.Interfaz;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASoftware.Enterprise.Servicios.WebApi.Controllers.v1
{

    /// <summary>
    /// Controlador de Customers de API
    /// </summary>
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CustomersController : Controller
    {
        private readonly ICustomerApplication _customerApplication;

        /// <summary>
        /// Constructor del Controller
        /// </summary>
        /// <param name="customerApplication">Interfaz para acceso a la capa de aplicacion</param>
        public CustomersController(ICustomerApplication customerApplication)
        {
            _customerApplication = customerApplication;
        }

        /// <summary>
        /// Metodo para crear un Customer
        /// </summary>
        /// <param name="customersDTO"> Objeto JSON esperado</param>
        /// <returns> Resultado de la operacion </returns>
        [HttpPost]
        public IActionResult Insert([FromBody] CustomersDTO customersDTO)
        {
            if (customersDTO == null)
                return BadRequest();

            var response = _customerApplication.Insert(customersDTO);

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }

        /// <summary>
        /// Metodo para actualizar un Customer
        /// </summary>
        /// <param name="customersDTO">Objeto JSON Esperado</param>
        /// <returns> Resultado de la Operacion</returns>
        [HttpPut]
        public IActionResult Update([FromBody] CustomersDTO customersDTO)
        {
            if (customersDTO == null)
                return BadRequest();

            var response = _customerApplication.Update(customersDTO);

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }

        /// <summary>
        /// Metodo para eliminar a un cliente
        /// </summary>
        /// <param name="CustomerID">CustomerID for delete</param>
        /// <returns> Resultado de la Operacion</returns>
        [HttpDelete("{CustomerID}")]
        public IActionResult Delete(string CustomerID)
        {
            if (string.IsNullOrEmpty(CustomerID))
                return BadRequest();

            var response = _customerApplication.Delete(CustomerID);

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }

        /// <summary>
        /// Endpoint para consultar un cliente por ID
        /// </summary>
        /// <param name="CustomerID">ID del Customer</param>
        /// <returns> Resultado de la operacion </returns>
        [HttpGet("{CustomerID}")]
        public IActionResult Get(string CustomerID)
        {
            if (string.IsNullOrEmpty(CustomerID))
                return BadRequest();

            var response = _customerApplication.Get(CustomerID);

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }

        /// <summary>
        /// Endpoint para consultar a todos los customers
        /// </summary>
        /// <returns> Resultado de la Operacion</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _customerApplication.GetAll();

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }

        /// <summary>
        /// Metodo asincrono para insertar un Customer
        /// </summary>
        /// <param name="customersDTO">Objeto Json Esperado</param>
        /// <returns>Resultado de la Operacion</returns>
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] CustomersDTO customersDTO)
        {
            if (customersDTO == null)
                return BadRequest();

            var response = await _customerApplication.InsertAsync(customersDTO);

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }

        /// <summary>
        /// Metodo asincrono para actualizar la informacion de un Customer
        /// </summary>
        /// <param name="customersDTO">Objeto Json Esperado</param>
        /// <returns> Resultado de la Operacion </returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomersDTO customersDTO)
        {
            if (customersDTO == null)
                return BadRequest();

            var response = await _customerApplication.UpdateAsync(customersDTO);

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }

        /// <summary>
        /// Metodo Asincrono para Eliminar a un Customer
        /// </summary>
        /// <param name="CustomerID">ID del Customer</param>
        /// <returns>Resultado de la Operacion</returns>
        [HttpDelete("{CustomerID}")]
        public async Task<IActionResult> DeleteAsync(string CustomerID)
        {
            if (string.IsNullOrEmpty(CustomerID))
                return BadRequest();

            var response = await _customerApplication.DeleteAsync(CustomerID);

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }

        /// <summary>
        /// Metodo asincrono para consultar un Customer por ID
        /// </summary>
        /// <param name="CustomerID">ID del Customer</param>
        /// <returns>Resultado de la operacion</returns>
        [HttpGet("{CustomerID}")]
        public async Task<IActionResult> GetAsync(string CustomerID)
        {
            if (string.IsNullOrEmpty(CustomerID))
                return BadRequest();

            var response = await _customerApplication.GetAsync(CustomerID);

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }

        /// <summary>
        /// Metodo asincrono para consulta de los Customers
        /// </summary>
        /// <returns>Resultado de la Operacion</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _customerApplication.GetAllAsync();

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }
    }
}
