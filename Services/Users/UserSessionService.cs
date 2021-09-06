using AutoMapper;
using ParkingApi.Exceptions;
using ParkingApi.Interfaces;
using ParkingApi.Models;
using ParkingApi.Repositories;
using ParkingApi.Requests.User.Session;
using ParkingApi.Responses.User;
using ParkingApi.Settings;

namespace ParkingApi.Services.Users
{
    public class UserSessionService : BaseService
    {
        private readonly ISession _sessionRepository;
        private readonly ICar _carRepository;
        private readonly IParking _parkingRepository;

        public UserSessionService(ISession sessionRepository,
                                ICar carRepository,
                                IParking parkingRepository,
                                ApiDbContext apiDbContext,
                                IMapper mapper) : base(apiDbContext, mapper)
        {
            _sessionRepository = sessionRepository;
            _carRepository = carRepository;
            _parkingRepository = parkingRepository;
        }
        public UserCarResponse CreateSession(long userId, CreateUserSessionRequest request)
        {
            if (_carRepository.CheckAccessUserToCar(userId, request.CarId) && _parkingRepository.CheckParkingById(request.ParkingId))
            {
                if (_sessionRepository.CheckSessionForCar(request.CarId) == false)
                {
                    Session session = MP.Map<Session>(request);
                    _sessionRepository.CreateSession(session);

                    Car car = _carRepository.GetCarById(session.CarId);

                    UserCarResponse response = MP.Map<UserCarResponse>(car);
                    return response;
                }
                else throw new AppException("The car is already parked!");
            }
            else throw new AppException("Invalid data!");
        }

        public void DeleteSessionByCar (long userId, long carId)
        {
            if (_carRepository.CheckAccessUserToCar(userId, carId))
            {
                _sessionRepository.DeleteSessionByCar(carId);
            }
            else throw new AppException("Not access!");
        }
    }
}
