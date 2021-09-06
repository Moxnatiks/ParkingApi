using ParkingApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ParkingApi.Interfaces
{
    public interface ISession
    {
        Session CreateSession(Session session);

        void DeleteSessionByCar(long carId);

        bool CheckSessionForCar(long carId);

        IEnumerable<Session> FindSessionByParkingId(long parkingId);
        IQueryable<Session> FilterSessionByParkingId(long parkingId);

    }
}
