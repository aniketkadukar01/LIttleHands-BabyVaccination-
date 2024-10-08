using LittleHands.DataModels;
using LittleHands.Models;

namespace LittleHands.Services
{
    public interface IUserService 
    {
        Task<UserDto> RegisterNewUser(UserDto userdto);
        Task<UserDto> UpdateUser(int id ,UserDto userdto);
        Task<UserDto> GetUserById(int id);
        Task<UserDto> DeleteUser(int id);
        Task<List<UserDto>> GetAllUser();
        
    }
}
