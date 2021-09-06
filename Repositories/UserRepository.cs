using Microsoft.EntityFrameworkCore;
using ParkingApi.Interfaces;
using ParkingApi.Models;
using ParkingApi.Settings;
using System.Linq;

namespace ParkingApi.Repositories
{
    public class UserRepository : IUser
    {
        private readonly ApiDbContext DB;
        public UserRepository(ApiDbContext apiDbContext)
        {
            DB = apiDbContext;
        }

        public bool CheckUserById(long userId)
        {
            User user = DB.Users.Find(userId);
            if (user != null) return true;
            else return false;
        }

        public User GetData(long userId)
        {
            User user = DB.Users.Where(b => b.Id == userId).Include(b => b.Cars).ThenInclude(Cars => Cars.Session).FirstOrDefault();
            if (user != null) return user;
            else return null;
        }
    }
}
