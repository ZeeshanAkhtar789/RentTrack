using Microsoft.EntityFrameworkCore;
using RentTrack.Api.Data;
using RentTrack.Api.Models;

namespace RentTrack.Api.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly RentTrackDbContext _context;
        public PropertyRepository(RentTrackDbContext context)
        {
            _context = context;
        }

        public async Task<Property> AddAsync(Property property)
        {
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
            return property;
        }

        public async Task<List<Property>> GetAllAsync()
        {
            return await _context.Properties.ToListAsync();
        }

        public async Task<Property?> GetPropertyByIdAsync(int id)
        {
            return await _context.Properties.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
