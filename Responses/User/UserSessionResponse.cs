using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Responses.User
{
    public class UserSessionResponse : BaseResponse
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long ParkingId { get; set; }
        public long CarId { get; set; }
    }
}
