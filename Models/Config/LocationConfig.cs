using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Models.Config
{
    public class LocationConfig : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(
                     new Location
                     {
                         Id = 1,
                         Latitude = 789.456,
                         Longitude = 456.789,
                         ParkingId = 1,
                     }, new Location
                     {
                         Id = 2,
                         Latitude = 789.456,
                         Longitude = 456.789,
                         ParkingId = 1,
                     }
                 );
        }
    }
}
