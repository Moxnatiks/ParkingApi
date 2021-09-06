using ParkingApi.Models;
using System.Collections.Generic;

namespace ParkingApi.Interfaces
{
    public interface IValet
    {
        IEnumerable<Valet> GetAllValets();
        Valet GetValetById(long valetId);
        Valet AddValet(Valet valet);
        Valet UpdateValet(Valet valet);
        bool CheckValetByEmail(string email);
        bool CheckValetById(long valetId);
        void DeleteValet(long valetId);
    }
}
