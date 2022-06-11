using System;

namespace PdIwtA_1b.ASP.Domain
{
    public class Product
    {
        public Product()
        {

        }

        public Product(Guid id, string name, bool isAvailable)
        {
            Id = id;
            Name = name;
            IsAvailable = isAvailable;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
    }
}
