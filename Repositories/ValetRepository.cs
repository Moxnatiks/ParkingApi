using ParkingApi.Interfaces;
using ParkingApi.Models;
using ParkingApi.Settings;
using System.Collections.Generic;
using System.Linq;

namespace ParkingApi.Repositories
{
    public class ValetRepository : IValet
    {
        private readonly ApiDbContext DB;
        public ValetRepository(ApiDbContext apiDbContext)
        {
            DB = apiDbContext;
        }

        public IEnumerable<Valet> GetAllValets()
        {
            IEnumerable<Valet> valets = DB.Valets.ToList();
            return valets;
        }

        public Valet GetValetById(long valetId)
        {
            Valet valet = DB.Valets.Find(valetId);
            return valet;
        }

        public Valet AddValet(Valet valet)
        {
            DB.Valets.Add(valet);
            DB.SaveChanges();
            return valet;
        }

        public Valet UpdateValet(Valet valet)
        {
            DB.Valets.Update(valet);
            DB.SaveChanges();
            return valet;
        }

        public bool CheckValetByEmail(string email)
        {
            Valet valet = DB.Valets.Where(b => b.Email == email).FirstOrDefault();
            if (valet != null) return true;
            else return false;
        }

        public bool CheckValetById(long valetId)
        {
            Valet valet = DB.Valets.Find(valetId);
            if (valet != null) return true;
            else return false;
        }

        public void DeleteValet(long valetId)
        {
            Valet valet = DB.Valets.Find(valetId);
            if (valet != null)
            {
                DB.Valets.Remove(valet);
                DB.SaveChanges();
            } 

        }

    }
}
