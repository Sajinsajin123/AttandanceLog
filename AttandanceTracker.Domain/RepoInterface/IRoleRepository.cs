using AttandanceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttandanceTracker.Domain.RepoInterface
{
    public interface IRoleRepository
    {
        Task<IList<Role>> GetAllRoles();
        Task<Role>GetRoleById(int id);
        Task<int>AddRole(Role role);
        Task<int>UpdateRole(Role role);
        Task<int>DeleteRole(int id);
    }
}
