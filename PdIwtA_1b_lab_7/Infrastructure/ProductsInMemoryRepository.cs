using test_7.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace test_7.Infrastructure
{
    public class ProductsInMemoryRepository : IProductsRepository
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product(Guid.Parse("9929DD1E-A785-45C5-81AF-3A12C5404D95"), "test", true)
        };

        public ProductsInMemoryRepository()
        {
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Guid id)
        {
            var productToDelete = _products.FirstOrDefault(x => x.Id.Equals(id));
            _products.Remove(productToDelete);
        }

        public bool Exists(Guid id)
        {
            return _products.Any(x => x.Id.Equals(id));
        }

        public Product GetById(Guid id)
        {
            return _products
                .FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Update(Product product)
        {
            var indexProductToUpdate = _products
                .FindIndex(x => x.Id.Equals(product.Id));
            _products[indexProductToUpdate] = product;
        }
    }
}
