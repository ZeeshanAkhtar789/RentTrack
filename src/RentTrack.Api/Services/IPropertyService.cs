using RentTrack.Api.Dtos.Properties;

namespace RentTrack.Api.Services
{
    public interface IPropertyService
    {
        Task<PropertyResponse> CreateAsync(CreatePropertyRequest request);

        Task<List<PropertyResponse>> GetAllAsync();

        Task<PropertyResponse?> GetPropertyByIdAsync(int id);
    }
}
