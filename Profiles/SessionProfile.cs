using AutoMapper;
using ParkingApi.Models;
using ParkingApi.Requests.User.Session;
using ParkingApi.Responses.User;
using ParkingApi.Responses.Valets;
using System.Collections.Generic;
using System.Linq;

namespace ParkingApi.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            //Source -> Target
            CreateMap<Session, UserSessionResponse>();
            CreateMap <Session, ValetSessionResponse> ();
            //CreateMap<List<Session>, List<ValetSessionResponse>>();
           // CreateMap<IEnumerable<Session>, IEnumerable<ValetSessionResponse>>();


            CreateMap<CreateUserSessionRequest, Session>();
        }
    }
}
