using ParkingApi.Interfaces;
using ParkingApi.Models;
using ParkingApi.Settings;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace ParkingApi.Repositories
{
    public class SessionRepository : ISession
    {
        private readonly ApiDbContext DB;
        public SessionRepository(ApiDbContext apiDbContext)
        {
            DB = apiDbContext;
        }

        public bool CheckSessionForCar(long carId)
        {
            Session session = DB.Sessions.Where(s => s.CarId == carId).FirstOrDefault();
            if (session != null) return true;
            else return false;
        }

        public Session CreateSession(Session session)
        {
            DB.Sessions.Add(session);
            DB.SaveChanges();
            return session;
        }

        public void DeleteSessionByCar(long carId)
        {
            Session session = DB.Sessions.Where(s => s.CarId == carId).FirstOrDefault();
            if (session != null)
            {
                DB.Sessions.Remove(session);
                DB.SaveChanges();
            }
        }

        public IEnumerable<Session> FindSessionByParkingId(long parkingId)
        {
            IEnumerable<Session> sessions = DB.Sessions.Where(s => s.ParkingId == parkingId).Include(c => c.Car);
            return sessions;
        }


        public IQueryable<Session> FilterSessionByParkingId(long parkingId)
        {
            IQueryable<Session> sessions = DB.Sessions.Where(s => s.ParkingId == parkingId).Include(c => c.Car);
            return sessions;
        }
    }
}
