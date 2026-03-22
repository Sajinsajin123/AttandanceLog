using AttandanceTracker.Application.Dto;
using AttandanceTracker.Application.InterfaceService;
using AttandanceTracker.Domain.Entities;
using AttandanceTracker.Domain.RepoInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttandanceTracker.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        public RoleService(IRoleRepository roleRepository) 
        {
            this.roleRepository=roleRepository;
        }
        public async Task<IList<RoleDto>> GetAllRole()
        {
            var roles = await roleRepository.GetAllRoles();

            return roles.Select(r => new RoleDto
            {
                RoleID = r.RoleID,
                RoleName = r.RoleName
            }).ToList();
        }


        public async Task<RoleDto> GetRoleById(int id)
        {
            var role = await roleRepository.GetRoleById(id);

            if (role == null)
                return null;

            return new RoleDto
            {
                RoleID = role.RoleID,
                RoleName = role.RoleName
            };
        }

        public async Task<int> AddRole(RoleDto roledto)
        {
            var role = new Role
            {
                RoleName = roledto.RoleName,
                Description = roledto.Description
            };

            return await roleRepository.AddRole(role);
        }

       
        public async Task<int> UpdateRole(RoleDto roleDto)
        {
            var role = new Role
            {
                RoleID = roleDto.RoleID,
                RoleName = roleDto.RoleName
            };

            return await roleRepository.UpdateRole(role);
        }

   
        public async Task<int> DeleteRole(int id)
        {
            return await roleRepository.DeleteRole(id);
        }
    }
}
