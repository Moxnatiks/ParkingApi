using ParkingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Repositories
{
    public interface ICar
    {
        Car GetCarById(long carId);
        Car CreateCar(Car car);
        Car UpdateCar(Car car);
        void DeleteCar(long carId);

        bool CheckCarByNumber(string number);
        bool CheckAccessUserToCar(long userId, long carId);

        void MakeAllDefaultFalse(long userId);
        void MakeOneDefaultTrue(long carId);
    }
}
