using System.ComponentModel.DataAnnotations;

namespace ParkingApi.Requests.User.Car
{
    public class UpdateUserCarRequest
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
