using System;

namespace ParkingApi.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            CreatedDate = DateTime.UtcNow;
        }
        public long Id { get; set; }
        public DateTimeOffset CreatedDate { get; init; }


    }
}
