using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Requests.Admin.Valet
{
    public class CreateAdminValetRequest
    {
        [Required]
        public string First_name { get; set; }
        [Required]
        public string Second_name { get; set; }
        public string Third_name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Jetton { get; set; }
        [Required]
        public string Email { get; set; }
        public bool? IsAccess { get; set; }
        [Required]
        [StringLength(8, ErrorMessage = "Minimum password length = 8")]
        public string Password { get; set; }
    }
}
