using System;

namespace test_7.Domain
{
    public interface IProductsRepository
    {
        bool Exists(Guid id);
        Product GetById(Guid id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Guid id);
   }
}


