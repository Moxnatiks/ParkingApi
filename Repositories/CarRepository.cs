using ParkingApi.Models;
using ParkingApi.Settings;
using System.Collections.Generic;
using System.Linq;

namespace ParkingApi.Repositories
{
    public class CarRepository : ICar
    {
        private readonly ApiDbContext DB;
        public CarRepository(ApiDbContext apiDbContext)
        {
            DB = apiDbContext;
        }

        public Car GetCarById(long carId)
        {
            Car car  = DB.Cars.Find(carId);
            return car;
        }
        public Car CreateCar(Car car)
        {
            DB.Cars.Add(car);
            DB.SaveChanges();
            return car;
        }

        public bool CheckCarByNumber(string number)
        {
            Car car = DB.Cars.Where(s => s.Number == number).FirstOrDefault();
            if (car != null) return true;
            else return false;
        }

        public bool CheckAccessUserToCar(long userId, long carId)
        {
            long[] ids = DB.Cars.Where(s => s.UserId == userId).Select(u => u.Id).ToArray();
            if (ids.Any(s => s == carId)) return true;
            else return false;

        }

        public void DeleteCar(long carId)
        {
            Car car = DB.Cars.Find(carId);
            if (car != null)
            {
                DB.Cars.Remove(car);
                DB.SaveChanges();
            }
        }

        public Car UpdateCar(Car car)
        {
            DB.Cars.Update(car);
            DB.SaveChanges();
            return car;
        }

        public void MakeAllDefaultFalse(long userId)
        {
            List<Car> cars = DB.Cars.Where(s => s.UserId == userId).ToList();
            foreach (Car car in cars)
            {
                car.IsDefaulte = false;
                DB.Cars.Update(car);
                DB.SaveChanges();
            }
        }

        public void MakeOneDefaultTrue(long carId)
        {
            Car car = DB.Cars.Find(carId);
            car.IsDefaulte = true;
            DB.Cars.Update(car);
            DB.SaveChanges();
        }
    }
}
