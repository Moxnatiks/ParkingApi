using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Models.Config
{
    public class SessionConfig : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            /*builder.HasOne(ss => ss.Car)
                .WithOne(s => s.Session);*/
                
                //.WithOne(s => s.Session)
                //.WithOne(s => s.Session)
                //.HasForeignKey<Car>(b => b.Id);
                

            builder.HasOne(ss => ss.Parking)
                .WithMany(s => s.Sessions)
                .HasForeignKey(ss => ss.ParkingId);

            builder.HasData
                (
                    new Session
                    {
                        Id = 1,
                        CarId = 1,
                        ParkingId = 1,
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now.AddHours(1),
                        CreatedDate = DateTimeOffset.Now
                    }
                );

        }
    }
}
