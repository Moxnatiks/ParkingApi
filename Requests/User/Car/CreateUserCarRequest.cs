using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Requests.User.Car
{
    public class CreateUserCarRequest
    {
        [Required]
        [MaxLength(8)]
        public string Number { get; set; }
        [Required]
        [MaxLength(20)]
        public string Model { get; set; }
        public string Color { get; set; }
    }
}
