using AutoMapper;
using ParkingApi.Interfaces;
using ParkingApi.Models;
using ParkingApi.Responses;
using ParkingApi.Settings;
using System.Collections.Generic;

namespace ParkingApi.Services
{
    public class ParkingService : BaseService
    {
        private readonly IParking _parkingRepository;

        public ParkingService(IParking parkingRepository,
                                ApiDbContext apiDbContext,
                                IMapper mapper) : base(apiDbContext, mapper)
        {
            _parkingRepository = parkingRepository;
        }
        public IEnumerable<ParkingResponse> GetAllParkings()
        {
            IEnumerable<Parking> listParkings = _parkingRepository.GetAllParkings();

            IEnumerable<ParkingResponse> response = MP.Map<IEnumerable<ParkingResponse>>(listParkings);

            return response;
        }
    }
}
