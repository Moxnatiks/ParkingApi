using ParkingApi.Models;
using System.Collections.Generic;

namespace ParkingApi.Interfaces
{
    public interface IParking
    {
        IEnumerable<Parking> GetAllParkings();
        bool CheckParkingById(long parkingId);
        Parking GetParkingById(long parkingId);
        Parking CreateParking(Parking parking);
        Parking UpdateParking(Parking parking);
        void DeleteParking(long parkingId);

        Parking GetParkingByIdForValet(long parkingId);
    }
}
