using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;
using PropertyManagementSystem.Services.Contracts;

namespace PropertyManagementSystem.Controllers
{
    [ApiController]
    [Route("api/properties")]
    public class PropertyApiController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        private readonly IMapper _mapper;

        public PropertyApiController(IPropertyService propertyService, IMapper mapper)
        {
            _propertyService = propertyService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllProperties()
        {
            return Ok(await _propertyService.GetAllProperties());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyById(int id)
        {
            return Ok(await _propertyService.GetPropertyById(id));
        }

        [HttpGet("{byLandlordId}")]
        public async Task<IActionResult> GetPropertyByLandlordId(int id)
        {
            return Ok(await _propertyService.GetPropertyByLandlordId(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProperty([FromBody] PropertyCreateDto propertyCreate)
        {
            var newProperty = await _propertyService.CreateProperty(propertyCreate);
            return CreatedAtRoute("GetPropertyById", new { id = newProperty.Id }, newProperty);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProperty(int id, [FromBody] PropertyUpdateDto propertyUpdate)
        {
            var propertyToUpdate = _mapper.Map<Property>(propertyUpdate);
            var updatedProperty = await _propertyService.UpdateProperty(id, propertyToUpdate);

            return Ok(_mapper.Map<PropertyUpdateDto>(updatedProperty));
        }
    }
}
