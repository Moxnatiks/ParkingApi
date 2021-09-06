using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Responses.Admin
{
    public class AdminValetResponse : BaseResponse
    {
        public string Full_name { get; set; }
        public string Phone { get; set; }
        public string Jetton { get; set; }
        public string Email { get; set; }
        public bool IsAccess { get; set; }
    }
}
