using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentTrack.Api.Models;

namespace RentTrack.Api.Data.Configurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        //Table Name
        builder.ToTable("Tbl_Properties");

        //Primary key and identity generation
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).UseIdentityColumn(1,1);

        //Required property infomation
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.PropertyType).IsRequired().HasMaxLength(50);
        builder.Property(p => p.StreetAddress).IsRequired().HasMaxLength(200);

        // Optional property information
        builder.Property(p => p.UnitNumber).HasMaxLength(50);
        builder.Property(p => p.SizeSqFt).HasPrecision(10, 2);
        builder.Property(p => p.BedroomsCount);
        builder.Property(p => p.BathroomsCount).HasPrecision(3, 1);
        builder.Property(p => p.Notes).HasMaxLength(1000);

        // Numeric defaults
        builder.Property(p => p.ParkingSpaces).HasDefaultValue(0);

        // Financial information
        builder.Property(p => p.BaseRentAmount).IsRequired().HasPrecision(18, 2);
        builder.Property(p => p.SecurityDepositAmount).IsRequired().HasPrecision(18, 2);
        builder.Property(p => p.CurrencyCode).IsRequired().HasMaxLength(3).HasDefaultValue("INR");

        // Status
        builder.Property(p => p.IsActive).IsRequired().HasDefaultValue(true);

        // Creation timestamp
        builder.Property(p => p.CreatedUtc).IsRequired().HasDefaultValueSql("SYSUTCDATETIME()");

    }
}
