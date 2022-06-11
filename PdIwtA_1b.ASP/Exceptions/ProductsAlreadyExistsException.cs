using System;

namespace PdIwtA_1b.ASP.Exceptions
{
    public class ProductsAlreadyExistsException: Exception
    {
        public ProductsAlreadyExistsException(Guid id): base($"Product with id {id} already exists.")
        {
            Id = id;
        }

        public Guid Id { get;  }
    }
}
