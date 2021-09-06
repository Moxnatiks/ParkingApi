using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingApi.Models
{
    public class Parking : BaseModel
    {
        public string Address { get; set; }
        public uint SecondFrom { get; set; }
        public uint SecondTo { get; set; }
        public double Price { get; set; }

        public virtual ICollection<Location> Locations { get; set; }

        public ICollection<Session> Sessions { get; set; }
    }
}
