using ParkingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Interfaces
{
    public interface IUser
    {
        bool CheckUserById(long userId);
        User GetData(long userId);
    }
}
