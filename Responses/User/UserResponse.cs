using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Responses.User
{
    public class UserResponse : BaseResponse
    {
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        //public bool IsAccess { get; set; }
        //public string Password { get; set; }
        //public byte[] StoredSalt { get; set; }

        public virtual ICollection<UserCarResponse> Cars { get; set; }
    }
}
