using AttandanceTracker.Application.Dto;
using AttandanceTracker.Application.InterfaceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttandanceTracke.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttandanceController : ControllerBase
    {
        private readonly IAttandanceService _service;

        public AttandanceController(IAttandanceService service)
        {
            _service = service;
        }

        // ✅ CREATE (POST)
        [HttpPost]
        public async Task<IActionResult> Add(AttandanceDto dto)
        {
            var id = await _service.AddAttandanceAsync(dto);
            return Ok(id);
        }

        // ✅ READ ALL (GET)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAttandanceAsync();
            return Ok(data);
        }

        // ✅ READ BY ID (GET)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetAttandanceById(id);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        // ✅ UPDATE (PUT)
        [HttpPut]
        public async Task<IActionResult> UpdateAttandanceAsync(AttandanceDto dto)
        {
            var result = await _service.UpdateAttandanceAsync(dto);

            if (result == 0)
                return BadRequest("Update failed");

            return Ok(result);
        }

        // ✅ DELETE (DELETE)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttandanceAsync(int id)
        {
            var result = await _service.DeleteAttandanceAsync(id);

            if (result == 0)
                return BadRequest("Delete failed");

            return Ok("Deleted successfully");
        }
    }
}
