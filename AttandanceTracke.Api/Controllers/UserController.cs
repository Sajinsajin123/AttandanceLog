using AttandanceTracker.Application.Dto;
using AttandanceTracker.Application.InterfaceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttandanceTracke.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUSerService userService;

        public UserController(IUSerService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UserDto dto)
        {
            var result = await userService.AddUser(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await userService.GetUserById(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserDto dto)
        {
            return Ok(await userService.UpdateUser(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await userService.DeleteUser(id));
        }
    }
}
