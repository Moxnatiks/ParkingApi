using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingApi.Settings;
using System;

namespace ParkingApi.Models.Config
{
    public class ValetConfig : IEntityTypeConfiguration<Valet>
    {
        public void Configure(EntityTypeBuilder<Valet> builder)
        {
            HashSalt data = new HashPassword("secret123").EncryptPassword();
            builder.Property(t => t.Phone).IsRequired(false);
            builder.Property(t => t.IsAccess).IsRequired(true);

            builder.HasData(
                    new Valet
                    {
                        Id = 1,
                        Full_name = "Valet Doe",
                        Email = "valet@gmail.com",
                        Phone = "+380994444333",
                        IsAccess = true,
                        Jetton = "123456",
                        Password = data.Hash,
                        StoredSalt = data.Salt,
                        CreatedDate = DateTimeOffset.Now
                    }
                );
        }
    }
}
