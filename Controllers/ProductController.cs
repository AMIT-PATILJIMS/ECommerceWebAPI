using AutoMapper;
using ECommerceWebAPI.DTO;
using ECommerceWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly EcommerceContext _ecommerceContext;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerController> _logger;

        public ProductController(EcommerceContext ecommerceContext, IMapper mapper, ILogger<CustomerController> logger)
        {
            _ecommerceContext = ecommerceContext;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<Product>> GetAllProducts()
        {
            var products = new List<Product>();
            try
            {
                products = await _ecommerceContext.Products.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return products;
        }

        [HttpGet("{ProductId}")]
        public async Task<ProductDTO> GetProductById(int ProductId)
        {
            _logger.LogInformation("try fetching the product by ProductId " + ProductId);

            var product = new Product();

            try
            {
                product = await _ecommerceContext.Products.FindAsync(ProductId);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            var productDTO = _mapper.Map<Product, ProductDTO>(product);

            return productDTO;
        }
    }
    
}
