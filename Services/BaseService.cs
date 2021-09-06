using AutoMapper;
using ParkingApi.Settings;

namespace ParkingApi.Services
{
    public abstract class BaseService
    {
        protected readonly ApiDbContext DB;
        protected readonly IMapper MP;
        public BaseService(ApiDbContext apiDbContext, IMapper mapper)
        {
            DB = apiDbContext;
            MP = mapper;
        }
    }
}
