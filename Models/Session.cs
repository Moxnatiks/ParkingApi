using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Models
{
    public class Session : BaseModel
    {
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public long ParkingId { get; set; }
        public Parking Parking { get; set; }

        [Required]
        public long CarId { get; set; }
        public Car Car { get; set; }
    }
}
