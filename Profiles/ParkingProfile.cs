using AutoMapper;
using ParkingApi.Models;
using ParkingApi.Requests.Admin.Parking;
using ParkingApi.Responses;
using ParkingApi.Responses.Valets;

namespace ParkingApi.Profiles
{
    public class ParkingProfile : Profile
    {
        public ParkingProfile()
        {
            //Source -> Target
            CreateMap<Parking, ParkingResponse>();
            CreateMap<Parking, Parking>();
            CreateMap<Parking, ValetParkingResponse>();

            CreateMap<CreateAdminParkingRequest, Parking>();
            CreateMap<UpdateAdminParkingRequest, Parking>();
 
        }
    }
}
