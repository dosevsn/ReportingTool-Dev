using AngularReporting.Services;
using Microsoft.AspNetCore.Mvc;


namespace AngularReporting.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<CustomerDto> Get()
        {
            var result = _service.GetCustomers();
            return result.Select(x=> new CustomerDto {
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName,
                FaxNumber = x.FaxNumber,
                PaymentDays = x.PaymentDays,
                PhoneNumber = x.PhoneNumber
            });
        }

        [HttpGet("{id}")]
        public CustomerDto Get(int id)
        {
            var customer = _service.GetCustomer(id);
            return new CustomerDto
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                FaxNumber = customer.FaxNumber,
                PaymentDays = customer.PaymentDays,
                PhoneNumber = customer.PhoneNumber
            };
        }
    }

    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int PaymentDays { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }       
    }
}
