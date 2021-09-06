using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Models
{
    public class Car : BaseModel
    {
        public string Number { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public bool IsDefaulte { get; set; }

        public long? UserId { get; set; }
        public virtual User User { get; set; }

        public Session? Session { get; set; }
    }
}

