using PdIwtA_1b.ASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PdIwtA_1b.ASP.Infrastructure
{
   

    public class UserInMemoryRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>
        {
            new User("test@email.com", "82034702738")
        };

        public UserInMemoryRepository()
        {
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void DeleteUser(string email)
        {
            var userToDelete = _users.FirstOrDefault(x => x.Email.Equals(email));
            _users.Remove(userToDelete);
        }

        public bool ExistsUser(string email)
        {
            return _users.Any(x => x.Email.Equals(email));
        }

        public User GetUserById(string email)
        {
            return _users
                .FirstOrDefault(x => x.Email.Equals(email));
        }

        public void UpdateUser(User user)
        {
            var indexUserToUpdate = _users
                .FindIndex(x => x.Email.Equals(user.Email));
            _users[indexUserToUpdate] = user;
        }
    }
}
