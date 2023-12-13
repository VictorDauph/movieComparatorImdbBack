using Microsoft.AspNetCore.Mvc;
using movieComparatorImdbBack.dto;
using movieComparatorImdbBack.Services.Services;
using movieComparatorImdbBack.models;

namespace movieComparatorImdbBack.Controllers
{
    [ApiController]
    [Route("/User")]
    public class UserController:Controller
    {
        UserService _userService = new UserService();

        [HttpPost("/newUser")]
        public void newUser(NewUserDto dto)
        {
            _userService.addUser(dto);
        }

        [HttpGet("/user/")]
        public User? getUser(int id)
        {
            return _userService.GetUserById(id);
        }
    }
}
