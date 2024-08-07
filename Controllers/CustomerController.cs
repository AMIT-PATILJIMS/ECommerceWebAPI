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
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(EcommerceContext ecommerceContext, IMapper mapper, ILogger<CustomerController> logger)
        {
            _ecommerceContext = ecommerceContext;
            _mapper = mapper;
            _logger = logger;
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
            _logger.LogInformation("Fetching the details of Customer By Customer Id :"+ id);
            var customer = new Customer();

            try
            {
                customer = await _ecommerceContext.Customers.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }

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

        [HttpPut]
        public async Task<int> InsertCustomer(CustomerDTO customerDTO)
        {
            var Customerdata = _mapper.Map<CustomerDTO, Customer>(customerDTO);

            await _ecommerceContext.Customers.AddAsync(Customerdata);
            await _ecommerceContext.SaveChangesAsync();

            return customerDTO.CustomerId;
        }

        [HttpPost]
        public async Task<int> BulkInsertCustomer(List<CustomerDTO> customerDTOs)
        {
            var customer = new Customer();

            foreach (var customerData in customerDTOs)
            {
                customer = _mapper.Map<CustomerDTO, Customer>(customerData);
                await _ecommerceContext.Customers.AddAsync(customer);
                await _ecommerceContext.SaveChangesAsync();
            }

            return customer.CustomerId;
        }
    }
}
