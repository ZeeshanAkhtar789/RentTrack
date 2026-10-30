using RentTrack.Api.Models;

namespace RentTrack.Api.Repositories
{
    public interface IPropertyRepository
    {
        Task<Property> AddAsync(Property property);

        Task<List<Property>> GetAllAsync();

        Task<Property?> GetPropertyByIdAsync(int id);
    }
}
