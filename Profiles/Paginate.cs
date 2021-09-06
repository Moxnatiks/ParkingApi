using AutoMapper;
using ParkingApi.Models;
using ParkingApi.Responses;
using ParkingApi.Responses.Valets;
using ParkingApi.Settings;

namespace ParkingApi.Profiles
{
    public class Paginate : Profile
    {

        public Paginate()
        {
            CreateMap<PagedList<Session>, PaginateResponse<ValetSessionResponse>>();
        }
    }
}
