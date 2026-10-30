using RentTrack.Api.Dtos.Properties;
using RentTrack.Api.Models;
using RentTrack.Api.Repositories;

namespace RentTrack.Api.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _repository;
        private readonly ILogger<PropertyService> _logger;

        public PropertyService(IPropertyRepository repository, ILogger<PropertyService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<PropertyResponse> CreateAsync(CreatePropertyRequest request)
        {
            _logger.LogInformation("Creating a new property of type {PropertyType}", request.PropertyType);
            var property = new Property
            {
                Name = request.Name,
                PropertyType = request.PropertyType,
                StreetAddress = request.StreetAddress,
                UnitNumber = request.UnitNumber,
                SizeSqFt = request.SizeSqFt,
                BedroomsCount = request.BedroomsCount,
                BathroomsCount = request.BathroomsCount,
                ParkingSpaces = request.ParkingSpaces,
                BaseRentAmount = request.BaseRentAmount,
                SecurityDepositAmount = request.SecurityDepositAmount,
                CurrencyCode = request.CurrencyCode,
                Notes = request.Notes
            };

            await _repository.AddAsync(property);
            _logger.LogInformation("Property Created successfully, PropertyId: {PropertyId}", property.Id);

            return new PropertyResponse
            {
                Id = property.Id,
                Name = property.Name,
                PropertyType = property.PropertyType,
                StreetAddress = property.StreetAddress,
                UnitNumber = property.UnitNumber,
                SizeSqFt = property.SizeSqFt,
                BedroomsCount = property.BedroomsCount,
                BathroomsCount = property.BathroomsCount,
                ParkingSpaces = property.ParkingSpaces,
                BaseRentAmount = property.BaseRentAmount,
                SecurityDepositAmount = property.SecurityDepositAmount,
                CurrencyCode = property.CurrencyCode,
                IsActive = property.IsActive,
                Notes = property.Notes,
                CreatedUtc = property.CreatedUtc
            };
        }

        public async Task<List<PropertyResponse>> GetAllAsync()
        {
            _logger.LogInformation("Fetching all Properties");
            var properties = await _repository.GetAllAsync();

            var response = properties.Select(p => new PropertyResponse
            {
                Id = p.Id,
                Name = p.Name,
                PropertyType = p.PropertyType,
                StreetAddress = p.StreetAddress,
                UnitNumber = p.UnitNumber,
                SizeSqFt = p.SizeSqFt,
                BedroomsCount = p.BedroomsCount,
                BathroomsCount = p.BathroomsCount,
                ParkingSpaces = p.ParkingSpaces,
                BaseRentAmount = p.BaseRentAmount,
                SecurityDepositAmount = p.SecurityDepositAmount,
                CurrencyCode = p.CurrencyCode,
                IsActive = p.IsActive,
                Notes = p.Notes,
                CreatedUtc = p.CreatedUtc
            }).ToList();

            _logger.LogInformation("Retrieved {PropertyCount} properties", response.Count);
            return response;
        }

        public async Task<PropertyResponse?> GetPropertyByIdAsync(int id)
        {
            _logger.LogInformation("Fetching the Property by id: {id}", id);
            var property = await _repository.GetPropertyByIdAsync(id);

            if (property == null)
            {
                _logger.LogWarning("Property not found with id: {id}", id);
                return null;
            }

            var response = new PropertyResponse
            {
                Id = property.Id,
                Name = property.Name,
                PropertyType = property.PropertyType,
                StreetAddress = property.StreetAddress,
                UnitNumber = property.UnitNumber,
                SizeSqFt = property.SizeSqFt,
                BedroomsCount = property.BedroomsCount,
                BathroomsCount = property.BathroomsCount,
                ParkingSpaces = property.ParkingSpaces,
                BaseRentAmount = property.BaseRentAmount,
                SecurityDepositAmount = property.SecurityDepositAmount,
                CurrencyCode = property.CurrencyCode,
                IsActive = property.IsActive,
                Notes = property.Notes,
                CreatedUtc = property.CreatedUtc
            };

            _logger.LogInformation("Property retrieved successfully with id: {id}", response.Id);
            return response;
        }
    }
}
