using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Responses
{
    public class LocationResponse
    {
        public long Id { get; init; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public long ParkingId { get; set; }
    }
}
