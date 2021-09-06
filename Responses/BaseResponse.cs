using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Responses
{
    public class BaseResponse
    {
        public long Id { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}
