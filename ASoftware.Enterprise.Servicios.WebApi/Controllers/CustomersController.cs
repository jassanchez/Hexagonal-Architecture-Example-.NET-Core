using ASoftware.Enterprise.Aplicacion.DTO;
using ASoftware.Enterprise.Aplicacion.Interfaz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASoftware.Enterprise.Servicios.WebApi.Controllers {
    [Authorize] 
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : Controller {
        private readonly ICustomerApplication _customerApplication;
        
        public CustomersController(ICustomerApplication customerApplication) {
            _customerApplication = customerApplication;
        }

        [HttpPost]
        public IActionResult Insert([FromBody]CustomersDTO customersDTO) {
            if(customersDTO == null)
                return BadRequest();
            
            var response = _customerApplication.Insert(customersDTO);
            
            if(response.IsSuccess) 
                return Ok(response);
            else 
                return BadRequest(response.Message);
        }

        [HttpPut]
        public IActionResult Update([FromBody] CustomersDTO customersDTO) {
            if (customersDTO == null)
                return BadRequest();

            var response = _customerApplication.Update(customersDTO);

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }

        [HttpDelete("{CustomerID}")]
        public IActionResult Delete(string CustomerID) {
            if (string.IsNullOrEmpty(CustomerID))
                return BadRequest();

            var response = _customerApplication.Delete(CustomerID);

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }

        [HttpGet("{CustomerID}")]
        public IActionResult Get(string CustomerID) {
            if (string.IsNullOrEmpty(CustomerID))
                return BadRequest();

            var response = _customerApplication.Get(CustomerID);

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }

        [HttpGet]
        public IActionResult GetAll() {
            var response = _customerApplication.GetAll();

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }


        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] CustomersDTO customersDTO) {
            if (customersDTO == null)
                return BadRequest();

            var response = await _customerApplication.InsertAsync(customersDTO);

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomersDTO customersDTO) {
            if (customersDTO == null)
                return BadRequest();

            var response = await _customerApplication.UpdateAsync(customersDTO);

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }

        [HttpDelete("{CustomerID}")]
        public async Task<IActionResult> DeleteAsync(string CustomerID) {
            if (string.IsNullOrEmpty(CustomerID))
                return BadRequest();

            var response = await _customerApplication.DeleteAsync(CustomerID);

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }

        [HttpGet("{CustomerID}")]
        public async Task<IActionResult> GetAsync(string CustomerID) {
            if (string.IsNullOrEmpty(CustomerID))
                return BadRequest();

            var response = await _customerApplication.GetAsync(CustomerID);

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() {
            var response = await _customerApplication.GetAllAsync();

            if (response.IsSuccess)
                return Ok(response);
            else
                return BadRequest(response.Message);
        }
    }
}
