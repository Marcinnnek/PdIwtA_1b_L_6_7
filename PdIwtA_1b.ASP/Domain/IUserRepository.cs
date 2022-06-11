using System;

namespace PdIwtA_1b.ASP.Domain
{
    public interface IUserRepository
    {
        bool ExistsUser(string email);
        User GetUserById(string email);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(string email);
    }
}


