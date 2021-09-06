using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Responses.User
{
    public class UserCarResponse : BaseResponse
    {
        public string Number { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public bool IsDefaulte { get; set; }
        public long? UserId { get; set; }

        public virtual UserSessionResponse Session { get; set; }
    }
}
