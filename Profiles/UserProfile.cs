using AutoMapper;
using ParkingApi.Models;
using ParkingApi.Responses.User;

namespace ParkingApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile ()
        {
            //Source -> Target
            CreateMap<User, UserResponse>();
        }
    }
}
