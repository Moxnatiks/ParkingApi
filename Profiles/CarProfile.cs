using AutoMapper;
using ParkingApi.Models;
using ParkingApi.Requests.User.Car;
using ParkingApi.Responses.User;
using ParkingApi.Responses.Valets;

namespace ParkingApi.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile ()
        {
            //Source -> Target
            CreateMap<Car, UserCarResponse>();
            CreateMap<Car, ValetCarResponse>();

            CreateMap<CreateUserCarRequest, Car>();
            CreateMap<UpdateUserCarRequest, Car>();

           

        }
    }
}
