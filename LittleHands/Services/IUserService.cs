using LittleHands.Models;

namespace LittleHands.Services
{
    public interface IUserService 
    {
        Task<User> RegisterNewUser(User user);
    }
}
