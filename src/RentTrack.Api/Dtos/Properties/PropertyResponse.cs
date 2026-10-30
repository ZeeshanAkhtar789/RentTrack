//The output contract returned by the API.
namespace RentTrack.Api.Dtos.Properties
{
    public class PropertyResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string PropertyType { get; set; } = string.Empty;

        public string StreetAddress { get; set; } = string.Empty;

        public string? UnitNumber { get; set; }

        public decimal? SizeSqFt { get; set; }

        public int? BedroomsCount { get; set; }

        public decimal? BathroomsCount { get; set; }

        public int ParkingSpaces { get; set; }

        public decimal BaseRentAmount { get; set; }

        public decimal SecurityDepositAmount { get; set; }

        public string CurrencyCode { get; set; } = "INR";

        public bool IsActive { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedUtc { get; set; }
    }
}
