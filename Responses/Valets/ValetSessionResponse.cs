using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Responses.Valets
{
    public class ValetSessionResponse : BaseResponse
    {
        public ValetSessionResponse() { }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long ParkingId { get; set; }
        public long CarId { get; set; }

        public virtual ValetCarResponse Car {get; set;}
    }
}
