using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingApi.Models
{
    public class Location
    {
        public long Id { get; init; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
        public long ParkingId { get; set; }
        public virtual Parking Parking { get; set; }
    }
}
