using Microsoft.AspNetCore.Mvc;
using PropertyManagementSystem.Models.DTO;
using PropertyManagementSystem.Services.Contracts;

namespace PropertyManagementSystem.Controllers
{
    [ApiController]
    [Route("api/requests")]
    public class RequestApiController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestApiController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet("request/{id}")]
        public async Task<IActionResult> GetRequestById(int id)
        {
            return Ok(await _requestService.GetRequestById(id));
        }

        [HttpGet("tenand/{tenandId}")]
        public async Task<IActionResult> GetRequestByTenandId(int tenandId)
        {
            return Ok(await _requestService.GetRequestsByTenandId(tenandId));
        }

        [HttpGet("property/{propertyId}")]
        public async Task<IActionResult> GetRequestsByPropertyId(int propertyId)
        {
            return Ok(await _requestService.GetRequestsByPropertyId(propertyId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromBody] RequestCreateDto requestDto)
        {
            var newRequest = await _requestService.CreateRequest(requestDto);
            //return CreatedAtRoute("GetRequestById", new { id = newRequest.Id }, newRequest);
            return Ok(newRequest);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            await _requestService.DeleteRequest(id);
            return Ok();
        }
    }
}
