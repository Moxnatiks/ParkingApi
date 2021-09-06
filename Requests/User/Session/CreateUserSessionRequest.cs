using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Requests.User.Session
{
    public class CreateUserSessionRequest
    {
        [Required]
        public long ParkingId { get; set; }
        [Required]
        public long CarId { get; set; }
    }
}
