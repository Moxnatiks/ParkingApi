using System.Collections.Generic;

namespace ParkingApi.Responses
{
    public class ParkingResponse : BaseResponse
    {
        public string Address { get; set; }
        public float Price { get; set; }
        public List<LocationResponse> Locations { get; set; }
    }
}
