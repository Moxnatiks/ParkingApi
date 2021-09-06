using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Requests.Admin.Parking
{
    public class UpdateAdminParkingRequest
    {
        [Required]
        [StringLength(3)]
        public string Address { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid number!")]
        public uint SecondFrom { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid number!")]
        public uint SecondTo { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid number!")]
        public double Price { get; set; }

        public virtual ICollection<CreateAdminLocationsRequest> Locations { get; set; }
    }
}
