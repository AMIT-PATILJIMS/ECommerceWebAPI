using AutoMapper;
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
        private readonly IMapper _mapper;

        public CustomerController(EcommerceContext ecommerceContext, IMapper mapper)
        {
            _ecommerceContext = ecommerceContext;
            _mapper = mapper;
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

            var customerDTO = _mapper.Map<Customer, CustomerDTO>(customer);
            /*
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
            */
            return customerDTO;
        }


    }
}
