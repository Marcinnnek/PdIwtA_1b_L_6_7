using System;

namespace PdIwtA_1b.ASP.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string email) : base($"Product with id {email} already exists.")
        {
            Email = email;
        }

        public string Email { get; }
    }
}
