using System;
using Microsoft.AspNetCore.Mvc;
using PdIwtA_1b.ASP.Domain;
using PdIwtA_1b.ASP.DTOs;
using PdIwtA_1b.ASP.Exceptions;




namespace PdIwtA_1b.ASP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository productsRepository)
        {
            _userRepository = productsRepository;
        }


        [HttpGet("[action]")]
        public IActionResult GetUser(string email)
        {
            var user = _userRepository.GetUserById(email);
            if (user is null)
                return NotFound();
            return Ok(new UserDTO(user));
        }

        [HttpPost("[action]")]
        public IActionResult AddUser(AddUserDTO User)
        {
            if (_userRepository.ExistsUser(User.Email))
                throw new UserAlreadyExistsException(User.Email);

            var user = new User(User.Email, User.Phone);
            _userRepository.AddUser(user);
            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult Update(UpdateUserDTO updateUser)
        {
            if (!_userRepository.ExistsUser(updateUser.Email))
                return NotFound();

            var user = new User(updateUser.Email, updateUser.Phone);
            _userRepository.UpdateUser(user);
            return Ok();
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(string email)
        {
            if (!_userRepository.ExistsUser(email))
                return NotFound();
            _userRepository.DeleteUser(email);
            return Ok();
        }


        [HttpPost("[action]")]
        public User Test(User user) => user;

    }
}
