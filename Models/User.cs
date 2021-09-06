using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Models
{
    public class User : BaseModel
    {
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsAccess { get; set; }
        public string Password { get; set; }
        public byte[] StoredSalt { get; set; }

        [NotMapped]
        public virtual ICollection<Car?>? Cars { get; set; }
    }
}

