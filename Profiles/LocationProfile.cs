using AutoMapper;
using ParkingApi.Models;
using ParkingApi.Requests.Admin.Parking;
using ParkingApi.Responses;

namespace ParkingApi.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationResponse>();

            CreateMap<CreateAdminLocationsRequest, Location>();

        }
    }
}
