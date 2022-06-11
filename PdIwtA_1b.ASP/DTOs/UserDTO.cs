using PdIwtA_1b.ASP.Domain;
using System;

namespace PdIwtA_1b.ASP.DTOs
{
    public class UserDTO
    {
        public UserDTO(User user)
        {
            Phone = user.Phone;
            Email = user.Email;

        }
        public string Email { get; init; }
        public string Phone { get; init; }

    }
}
