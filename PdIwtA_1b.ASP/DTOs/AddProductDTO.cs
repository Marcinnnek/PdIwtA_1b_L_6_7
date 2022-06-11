using System;

namespace PdIwtA_1b.ASP.DTOs
{
    public class AddProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
    }
}
