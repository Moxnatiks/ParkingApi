using AutoMapper;
using ParkingApi.Exceptions;
using ParkingApi.Interfaces;
using ParkingApi.Models;
using ParkingApi.Responses.User;
using ParkingApi.Settings;

namespace ParkingApi.Services.Users
{
    public class UserService : BaseService
    {
        private readonly IUser _userRepository;

        public UserService(IUser userRepository,
                                ApiDbContext apiDbContext,
                                IMapper mapper) : base(apiDbContext, mapper)
        {
            _userRepository = userRepository;
        }

        public UserResponse GetData (long userId)
        {
            if (_userRepository.CheckUserById(userId))
            {
                Models.User user = _userRepository.GetData(userId);

                UserResponse response = MP.Map<UserResponse>(user);

                return response;

            } else throw new AppException("Error!");
            
        }

    }
}
