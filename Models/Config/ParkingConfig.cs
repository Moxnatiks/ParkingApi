using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace ParkingApi.Models.Config
{
    public class ParkingConfig : IEntityTypeConfiguration<Parking>
    {
        public void Configure(EntityTypeBuilder<Parking> builder)
        {
            builder
                .HasMany(b => b.Locations)
                .WithOne(s => s.Parking)
                .HasForeignKey(s => s.ParkingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(t => t.Price).HasDefaultValue(0);
            builder.Property(t => t.SecondFrom).HasDefaultValue(0);
            builder.Property(t => t.SecondTo).HasDefaultValue(0);

            var Ids = 1;
            var parkingFaker = new Faker<Parking>()
                .RuleFor(o => o.Id, f => Ids++)
                .RuleFor(o => o.Address, f => f.Address.FullAddress())
                .RuleFor(o => o.Price, f => f.Random.Double(5.0 , 10.0))
                .RuleFor(o => o.SecondFrom, f => f.Random.UInt(10000, 20000))
                .RuleFor(o => o.SecondTo, f => f.Random.UInt(10000, 20000))
                .RuleFor(o => o.CreatedDate, DateTimeOffset.Now);

            List<Parking> parkings = parkingFaker.Generate(10);

            builder.HasData( parkings );

        }
    }
}
