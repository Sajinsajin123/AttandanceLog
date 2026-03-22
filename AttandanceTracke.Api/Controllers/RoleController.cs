using AttandanceTracker.Application.Dto;
using AttandanceTracker.Application.InterfaceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttandanceTracke.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;
        public RoleController(IRoleService roleService)
        { 
            this.roleService = roleService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var role = await roleService.GetRoleById(id);

            if (role == null)
                return NotFound();

            return Ok(role);
        }


        [HttpPost]
        public async Task<IActionResult> AddRole(RoleDto roleDto)
        {
            int id;
            try
            {
                id = await roleService.AddRole(roleDto);
                if (id==0)
                {
                    return BadRequest("Failed to Add Role");
                }
                
            }
            catch(Exception ex) 
            {
                return BadRequest(ex);
            }
          
            return CreatedAtAction(nameof(GetRoleById), new {id=id},null);
        }

    
        [HttpPut]
        public async Task<IActionResult> UpdateRole(RoleDto roleDto)
        {
            var result = await roleService.UpdateRole(roleDto);
            return Ok(result);
        }

     
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await roleService.DeleteRole(id);
            return Ok(result);
        }
    }
}
