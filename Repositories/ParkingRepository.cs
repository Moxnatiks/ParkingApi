using ParkingApi.Interfaces;
using ParkingApi.Models;
using ParkingApi.Settings;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace ParkingApi.Repositories
{
    public class ParkingRepository : IParking
    {
        private readonly ApiDbContext DB;
        public ParkingRepository(ApiDbContext apiDbContext)
        {
            DB = apiDbContext;
        }

        public IEnumerable<Parking> GetAllParkings()
        {  
            List<Parking> parking = DB.Parkings.Include(e => e.Locations).ToList();
            return parking;
        }
        public bool CheckParkingById(long parkingId)
        {
            Parking parking = DB.Parkings.Find(parkingId);
            if (parking != null)    return true;
            else                    return false;
        }

        public Parking GetParkingById(long parkingId)
        {
            Parking parking = DB.Parkings.Where(b => b.Id == parkingId).Include(b => b.Locations).FirstOrDefault();
            if (parking != null) return parking;
            else return null;
        }

        public Parking CreateParking(Parking parking)
        {
            DB.Parkings.Add(parking);
            DB.SaveChanges();
            return parking;
        }

        public Parking UpdateParking(Parking parking)
        {
            DB.Parkings.Update(parking);
            DB.SaveChanges();
            return parking;
        }

        public void DeleteParking(long parkingId)
        {
            Parking parking = DB.Parkings.Find(parkingId);
            if (parking != null)
            {
                DB.Parkings.Remove(parking);
                DB.SaveChanges();
            }
        }

        public Parking GetParkingByIdForValet(long parkingId)
        {
            Parking parking = DB.Parkings.Where(b => b.Id == parkingId)
                .Include(b => b.Sessions)
                .ThenInclude(Sessions => Sessions.Car).FirstOrDefault();
            return parking;
        }
    }
}
