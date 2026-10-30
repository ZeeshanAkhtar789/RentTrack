//The input contract for creating a property.
using System.ComponentModel.DataAnnotations;


namespace RentTrack.Api.Dtos.Properties
{
    public class CreatePropertyRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string PropertyType { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string StreetAddress { get; set; } = string.Empty;

        [StringLength(50)]
        public string? UnitNumber { get; set; }

        [Range(typeof(decimal), "0.01", "99999999.99")]
        public decimal? SizeSqFt { get; set; }

        [Range(0, 100)]
        public int? BedroomsCount { get; set; }

        [Range(typeof(decimal), "0.1", "99.9")]
        public decimal? BathroomsCount { get; set; }

        [Range(0, 100)]
        public int ParkingSpaces { get; set; } = 0;

        [Range(typeof(decimal), "0.01", "9999999999999999.99")]
        public decimal BaseRentAmount { get; set; }

        [Range(typeof(decimal), "0", "9999999999999999.99")]
        public decimal SecurityDepositAmount { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string CurrencyCode { get; set; } = "INR";

        [StringLength(1000)]
        public string? Notes { get; set; }
    }
}
