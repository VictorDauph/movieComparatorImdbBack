using movieComparatorImdbBack.dto;
using movieComparatorImdbBack.models;
using movieComparatorImdbBack.Services.EntityService;

namespace movieComparatorImdbBack.Services.Services
{
    public class UserService
    {
        UserRepository _userRepository = new UserRepository();

        public void addUser(NewUserDto dto) {
            User user = new User(dto);
            _userRepository.addUser(user);
        }

        public User? GetUserById(int id)
        {
            return _userRepository.getUserById(id);
        }
    }
}
