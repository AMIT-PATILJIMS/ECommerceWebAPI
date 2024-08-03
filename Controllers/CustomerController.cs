using ECommerceWebAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly EcommerceContext _ecommerceContext;

        public CustomerController(EcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        [HttpGet]
        public async Task<List<Customer>> GetAllCustomers()
        {
            var customers = new List<Customer>();
            try
            {
                customers = await _ecommerceContext.Customers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return customers;
        }

        [HttpGet("{id}")]
        public async Task<CustomerDTO> GetCustomerById(int id)
        {
            var customer = await _ecommerceContext.Customers.FindAsync(id);

            CustomerDTO customerDTO = new CustomerDTO();

            if (customer != null)
            {
                customerDTO = new CustomerDTO()
                {
                    CustomerId = customer.CustomerId,
                    Name = customer.Name,
                    Email = customer.Address,
                    Address = customer.Address
                };
            }

            return customerDTO;
        }


    }
}
