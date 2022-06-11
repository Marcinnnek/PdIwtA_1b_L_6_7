using System.ComponentModel.DataAnnotations;

namespace PdIwtA_1b.ASP.Domain
{
    public class User
    {
        public User(string email, string phone)
        {
            Email = email;
            Phone = phone;
        }


        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
