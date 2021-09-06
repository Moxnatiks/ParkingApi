using AutoMapper;
using ParkingApi.Exceptions;
using ParkingApi.Interfaces;
using ParkingApi.Models;
using ParkingApi.Requests.Admin.Parking;
using ParkingApi.Responses;
using ParkingApi.Settings;
using System.Collections.Generic;

namespace ParkingApi.Services.AdminParking
{
    public class AdminParkingService : BaseService
    {
        private readonly IParking _parkingRepository;

        public AdminParkingService(IParking parkingRepository,
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

        public ParkingResponse CreateParking(CreateAdminParkingRequest request)
        {
            Parking parking = MP.Map<Parking>(request);

            parking = _parkingRepository.CreateParking(parking);

            ParkingResponse response = MP.Map<ParkingResponse>(parking);

            return response;
        }
        public ParkingResponse UpdateParking(UpdateAdminParkingRequest request, long parkingId)
        {
            if (_parkingRepository.CheckParkingById(parkingId))
            {
                Parking parking = MP.Map<Parking>(request);

                Parking existParking = _parkingRepository.GetParkingById(parkingId);

                existParking.Address = parking.Address;
                existParking.Price = parking.Price;
                existParking.SecondFrom = parking.SecondFrom;
                existParking.SecondTo = parking.SecondTo;
                existParking.Locations = parking.Locations;

                existParking = _parkingRepository.UpdateParking(existParking);

                ParkingResponse response = MP.Map<ParkingResponse>(existParking);

                return response;
            }
            else throw new AppException("Parking not found!");
        }
        public void DeleteParking(long parkingId)
        {
            _parkingRepository.DeleteParking(parkingId);
        }
    }
}
