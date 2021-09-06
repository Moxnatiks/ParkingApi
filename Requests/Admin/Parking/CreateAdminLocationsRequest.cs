using System;
using System.ComponentModel.DataAnnotations;

namespace ParkingApi.Requests.Admin.Parking
{
    public class CreateAdminLocationsRequest
    {
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid number!")]
        public double Latitude { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid number!")]
        public double Longitude { get; set; }
    }
}
