using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        ICustomerService _customerService;
        public CustomersController(ICustomerService customerService) {
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() {
            var result = _customerService.GetAll();
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id) {
            var result = _customerService.GetById(id);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer) {
            var result = _customerService.Add(customer);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("delete")]
        public IActionResult Delete(Customer customer) {
            var result = _customerService.Delete(customer);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("update")]
        public IActionResult Update(Customer customer) {
            var result = _customerService.Update(customer);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcustomersdetailbyid")]
        public IActionResult GetCustomersDetailById(int id)
        {
            var result = _customerService.GetCustomersDetailById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcustomersdetail")]
        public IActionResult GetCustomersDetail()
        {
            var result = _customerService.GetCustomersDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
