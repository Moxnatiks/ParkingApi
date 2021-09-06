using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Responses.Valets
{
    public class ValetParkingResponse : BaseResponse
    {
        public string Address { get; set; }
        public float Price { get; set; }
        public virtual ICollection<ValetSessionResponse> Sessions { get; set; }
    }
}
