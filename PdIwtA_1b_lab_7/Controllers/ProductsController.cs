using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using test_7.Domain;
using test_7.DTOs;
using test_7.Exceptions;

namespace test_7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet("[action]")]
        public IActionResult Get(Guid id)
        {
            var product = _productsRepository.GetById(id);
            if (product is null)
                return NotFound();
            return Ok(new ProductDTO(product));
        }

        [HttpPost("[action]")]
        public IActionResult Add(AddProductDTO addProduct)
        {
            if (_productsRepository.Exists(addProduct.Id))
                throw new ProductsAlreadyExistsException(addProduct.Id);

            var product = new Product(addProduct.Id, addProduct.Name, addProduct.IsAvailable);
            _productsRepository.Add(product);
            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult Update(UpdateProductDTO updateProduct)
        {
            if (!_productsRepository.Exists(updateProduct.Id))
                return NotFound();

            var product = new Product(updateProduct.Id, updateProduct.Name, updateProduct.IsAvailable);
            _productsRepository.Update(product);
            return Ok();
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(Guid id)
        {
            if (!_productsRepository.Exists(id))
                return NotFound();
            _productsRepository.Delete(id);
            return Ok();
        }
    }
}
