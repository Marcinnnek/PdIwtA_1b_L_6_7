using System;
using System.ComponentModel.DataAnnotations;

namespace PdIwtA_1b.ASP.DTOs
{
    public class UpdateUserDTO
    {

        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
