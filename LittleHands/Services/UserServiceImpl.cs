using AutoMapper;
using LittleHands.Models;
using LittleHands.Repositories;
using LittleHands.Validators;


namespace LittleHands.Services
{
    public class UserServiceImpl : IUserService
    {
        private readonly ILittleHandsRepo<User> _littleHandsRepo;
        private readonly UserValidator _userValidator;
        private readonly IMapper _mapper;

        public UserServiceImpl(ILittleHandsRepo<User> littleHandsRepo
            , UserValidator userValidator, IMapper mapper)
        {
            _littleHandsRepo = littleHandsRepo;
            _userValidator = userValidator;
            _mapper = mapper;
        }

        public async Task<User> RegisterNewUser(User user)
        {
            await ValidationHelper.ValidateAsync(user , _userValidator);
            return await _littleHandsRepo.CreateAsync(user);
        }
    }
}
