using System;
using Microsoft.AspNetCore.Mvc;
using PdIwtA_1b.ASP.Domain;
using PdIwtA_1b.ASP.DTOs;
using PdIwtA_1b.ASP.Exceptions;

namespace PdIwtA_1b.ASP.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
