using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingApi.Settings;
using System;

namespace ParkingApi.Models.Config
{
    public class AdminConfig : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            HashSalt data = new HashPassword("secret123").EncryptPassword();
            builder.HasData(
                new Admin
                {
                    Id = 1,
                    Full_name = "John Doe",
                    Email = "admin@gmail.com",
                    Password = data.Hash,
                    StoredSalt = data.Salt,
                    CreatedDate = DateTimeOffset.Now
                }
            );
        }
    }
}
