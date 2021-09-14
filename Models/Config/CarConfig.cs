using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi.Models.Config
{
    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(t => t.Number).IsRequired().HasMaxLength(8);
            builder.Property(t => t.Model).IsRequired().HasMaxLength(20);
            builder.Property(t => t.Color).IsRequired(false).HasDefaultValue(null);
            builder.Property(t => t.IsDefaulte).HasDefaultValue(false);
            builder.Property(t => t.UserId).IsRequired(false).HasDefaultValue(null);

            /*builder.HasOne(ss => ss.Session)
                .WithOne(s => s.Car)
                .HasForeignKey<Car>(b => b.Id);*/
            var Ids = 1;
            var carFaker = new Faker<Car>()
                .RuleFor(o => o.Id, f => Ids++)
                .RuleFor(o => o.Model, f => f.Random.String(8, 'A', 'X'))
                .RuleFor(o => o.Number, f => f.Random.String(2, 'A', 'X') + f.Random.String(4, '0', '9') + f.Random.String(2, 'A', 'X'))
                .RuleFor(o => o.Color, f => f.Internet.Color())
                .RuleFor(o => o.IsDefaulte, false)
                .RuleFor(o => o.UserId, f => f.Random.Int(1,2))
                .RuleFor(o => o.CreatedDate, DateTimeOffset.Now);

            List<Car> cars = carFaker.Generate(10);

            builder.HasData(
                cars
                /*new Car
                {
                    Id = 1,
                    Model = "Volga",
                    Number = "AA1234BB",
                    Color = "green",
                    IsDefaulte = true,
                    UserId = 1,
                    CreatedDate = DateTimeOffset.Now
                },
                new Car
                {
                    Id = 2,
                    Model = "Nissan",
                    Number = "AA4321BB",
                    Color = "red",
                    IsDefaulte = false,
                    UserId = 1,
                    CreatedDate = DateTimeOffset.Now
                }*/
                );
        }
    }
}


