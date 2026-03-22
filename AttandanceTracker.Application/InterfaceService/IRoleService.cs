using AttandanceTracker.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttandanceTracker.Application.InterfaceService
{
    public interface IRoleService
    {
        Task<IList<RoleDto>> GetAllRole();
        Task<RoleDto> GetRoleById(int id);
        Task<int> AddRole(RoleDto roledto);
        Task<int>UpdateRole(RoleDto roleDto);
        Task<int>DeleteRole(int id);
    }
}
