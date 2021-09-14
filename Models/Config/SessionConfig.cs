using Bogus;
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

            var IdsS = 1;
            var IdsC = 1;
            var sessionFaker = new Faker<Session>()
                .RuleFor(o => o.Id, f => IdsS++)
                .RuleFor(o => o.CarId, f => IdsC++)
                .RuleFor(o => o.ParkingId, f => f.Random.Int(1 , 2))
                .RuleFor(o => o.StartTime, DateTime.Now)
                .RuleFor(o => o.EndTime, DateTime.Now.AddHours(1))
                .RuleFor(o => o.CreatedDate, DateTimeOffset.Now);

            List<Session> sessions = sessionFaker.Generate(10);

            builder.HasData
                (
                sessions
/*                    new Session
                    {
                        Id = 1,
                        CarId = 1,
                        ParkingId = 1,
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now.AddHours(1),
                        CreatedDate = DateTimeOffset.Now
                    }*/
                );

        }
    }
}
