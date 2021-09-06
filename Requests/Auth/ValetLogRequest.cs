using System.ComponentModel.DataAnnotations;

namespace ParkingApi.Requests.Auth
{
    public class ValetLogRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
