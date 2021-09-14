using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingApi.Settings;
using System;

namespace ParkingApi.Models.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            HashSalt data = new HashPassword("secret123").EncryptPassword();
            builder
                .HasMany(b => b.Cars)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId)
                //.WillCascadeOnDelete(false);
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(t => t.IsAccess).IsRequired(true);
            builder.Property(t => t.Email).IsRequired(false);

            builder.HasData(
                    new User
                    {
                        Id = 1,
                        First_name = "John",
                        Last_name = "Doe",
                        IsAccess = true,
                        Phone = "+380994444333",
                        Email = "string",
                        Password = data.Hash,
                        StoredSalt = data.Salt,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new User
                    {
                        Id = 2,
                        First_name = "Ruslan",
                        Last_name = "Tonus",
                        IsAccess = true,
                        Phone = "+380993334444",
                        Email = "user@gmail.com",
                        Password = data.Hash,
                        StoredSalt = data.Salt,
                        CreatedDate = DateTimeOffset.Now
                    }
                );

        }
    }
}
