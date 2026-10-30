using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentTrack.Api.Data;
using RentTrack.Api.Dtos.Properties;
using RentTrack.Api.Models;
using RentTrack.Api.Services;

namespace RentTrack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        public PropertiesController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpPost]
        public async Task<ActionResult<PropertyResponse>> CreateProperty(CreatePropertyRequest request)
        {
            var response = await _propertyService.CreateAsync(request);
            return CreatedAtAction(nameof(GetPropertyById), new { id = response.Id }, response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyResponse>>> GetAllProperties()
        {
            var properties = await _propertyService.GetAllAsync();
            return Ok(properties);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PropertyResponse>> GetPropertyById(int id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);

            if(property == null)
            {
                return NotFound($"Property not found with id: {id}");
            }

            return Ok(property);
        }
    }
}
