using AutoMapper;
using LittleHands.CustomHttpExceptions;
using LittleHands.DataModels;
using LittleHands.Models;
using LittleHands.Repositories;
using LittleHands.Validators;
using System.Net;


namespace LittleHands.Services
{
    public class UserServiceImpl : IUserService
    {
        private readonly ILittleHandsRepo<User> _littleHandsRepo;
        private readonly UserDtoValidator _userDtoValidator;
        private readonly IMapper _mapper;

        public UserServiceImpl(ILittleHandsRepo<User> littleHandsRepo
            , UserDtoValidator userDtoValidator, IMapper mapper)
        {
            _littleHandsRepo = littleHandsRepo;
            _userDtoValidator = userDtoValidator;
            _mapper = mapper;
        }

        public async Task<UserDto> DeleteUser(int id)
        {
            User user = await _littleHandsRepo.DeleteAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetAllUser()
        {
            List<User> userList = await _littleHandsRepo.GetAllAsync();
            return _mapper.Map<List<UserDto>>(userList);
        }

        public async Task<UserDto> GetUserById(int id)
        {
            User user = await _littleHandsRepo.GetByIdAsync(id);
            UserDto userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<UserDto> RegisterNewUser(UserDto userdto)
        {
            await ValidationHelper.ValidateAsync(userdto, _userDtoValidator);
            User user = _mapper.Map<User>(userdto);
            await _littleHandsRepo.CreateAsync(user);
            return userdto;
        }

        public async Task<UserDto> UpdateUser(int id , UserDto userdto)
        {
            User findUser = await _littleHandsRepo.GetByIdAsync(id);
            await ValidationHelper.ValidateAsync(userdto, _userDtoValidator);
            findUser = _mapper.Map<User>(userdto);
            await _littleHandsRepo.UpdateAsync(findUser);
            return userdto;
        }
    }
}
