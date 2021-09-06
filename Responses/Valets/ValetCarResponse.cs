using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Responses.Valets
{
    public class ValetCarResponse : BaseResponse
    {
        public string Number { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public long UserId { get; set; }
    }
}
