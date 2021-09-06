using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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



            builder.HasData(
                    new Parking
                    {
                        Id = 1,
                        Address = "There and here?",
                        Price = 5.45,
                        SecondFrom = 123456,
                        SecondTo = 654321,
                        CreatedDate = DateTimeOffset.Now
                    }
                );

        }
    }
}
