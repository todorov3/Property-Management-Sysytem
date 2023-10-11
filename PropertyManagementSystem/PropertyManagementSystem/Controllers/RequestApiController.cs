using Microsoft.AspNetCore.Mvc;
using PropertyManagementSystem.Models.DTO;
using PropertyManagementSystem.Services.Contracts;

namespace PropertyManagementSystem.Controllers
{
    [ApiController]
    [Route("api/requests")]
    public class RequestApiController : ControllerBase
    {
        private readonly IRequestService _requestServce;

        public RequestApiController(IRequestService requestService)
        {
            _requestServce = requestService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestById(int id)
        {
            return Ok(await _requestServce.GetRequestById(id));
        }

        [HttpGet("{tenandId}")]
        public async Task<IActionResult> GetRequestByTenandId(int tenandId)
        {
            return Ok(await _requestServce.GetRequestsByTenandId(tenandId));
        }

        [HttpGet("{propertyId}")]
        public async Task<IActionResult> GetRequestsByPropertyId(int propertyId)
        {
            return Ok(await _requestServce.GetRequestsByPropertyId(propertyId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromBody] RequestCreateDto requestDto)
        {
            var newRequest = await _requestServce.CreateRequest(requestDto);
            return CreatedAtRoute("GetRequestById", new { id = newRequest.Id }, newRequest);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            await _requestServce.DeleteRequest(id);
            return Ok();
        }
    }
}
