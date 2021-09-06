using AutoMapper;
using ParkingApi.Exceptions;
using ParkingApi.Models;
using ParkingApi.Repositories;
using ParkingApi.Requests.User.Car;
using ParkingApi.Responses.User;
using ParkingApi.Settings;

namespace ParkingApi.Services.User
{
    public class UserCarService : BaseService
    {
        private readonly ICar _carRepository;

        public UserCarService(ICar carRepository,
                                ApiDbContext apiDbContext,
                                IMapper mapper) : base(apiDbContext, mapper)
        {
            _carRepository = carRepository;
        }

        public UserCarResponse AddCar (long user_id, CreateUserCarRequest request)
        {
            request.Number = ConvertNumber(request.Number);
            if (_carRepository.CheckCarByNumber(request.Number) == false)
            {
                Car car = MP.Map<Car>(request);
                car.UserId = user_id;
                car = _carRepository.CreateCar(car);

                UserCarResponse response = MP.Map<UserCarResponse>(car);
                return response;
            }
            else throw new AppException("The number is already taken!");
        }

        public UserCarResponse UpdateCar(long userId, UpdateUserCarRequest request, long carId)
        {
            request.Number = ConvertNumber(request.Number);
            if (_carRepository.CheckAccessUserToCar(userId, carId))
            {
                Car requestCar = MP.Map<Car>(request);
                Car existCar = _carRepository.GetCarById(carId);

                existCar.Model = requestCar.Model;
                existCar.Color = request.Color;
                if (existCar.Number != requestCar.Number)
                {
                    if (_carRepository.CheckCarByNumber(request.Number) == false)
                    {
                        existCar.Number = requestCar.Number;
                    }
                    else throw new AppException("The number is already taken!");
                }

                existCar = _carRepository.UpdateCar(existCar);

                UserCarResponse response = MP.Map<UserCarResponse>(existCar);
                return response;
            }
            else throw new AppException("Not access!");
        }

        public string ConvertNumber (string text)
        {
            text = text.Replace("  ", string.Empty);
            text = text.Trim().Replace(" ", string.Empty);
            text = text.ToUpper();
            return text;
        }

        public void DeleteCar (long userId, long carId)
        {
            if (_carRepository.CheckAccessUserToCar(userId, carId))
            {
                _carRepository.DeleteCar(carId);
            }
            else throw new AppException("Not access!"); 
        }

        public void IsDefault(long userId, long carId)
        {
            if (_carRepository.CheckAccessUserToCar(userId, carId))
            {
                _carRepository.MakeAllDefaultFalse(userId);
                _carRepository.MakeOneDefaultTrue(carId);
            }
            else throw new AppException("Not access!");

        }

    }
}
