using AutoMapper;
using ParkingApi.Models;
using ParkingApi.Requests.Admin.Valet;
using ParkingApi.Responses.Admin;

namespace ParkingApi.Profiles
{
    public class ValetProfile : Profile
    {
        //Source -> Target
        public ValetProfile()
        {
            CreateMap<Valet, AdminValetResponse>();

            CreateMap<CreateAdminValetRequest, Valet>()
                .ForMember(x => x.Full_name,
                x => x.MapFrom(m => m.First_name + " " + m.Second_name + " " + m.Third_name));
            CreateMap<UpdateAdminValetRequest, Valet>()
                .ForMember(x => x.Full_name,
                x => x.MapFrom(m => m.First_name + " " + m.Second_name + " " + m.Third_name));
        }
    }
}
