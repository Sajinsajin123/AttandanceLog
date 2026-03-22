using AttandanceTracker.Application.Dto;
using AttandanceTracker.Domain.Entities;
using AttandanceTracker.Domain.RepoInterface;
using AttandanceTracker.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttandanceTracker.Infrastructure.Repository
{
    public class RoleRepostory : IRoleRepository
    {
        private readonly AttandanceTrackerDbContext dbContext;
        public RoleRepostory(AttandanceTrackerDbContext dbContext) {
            this.dbContext = dbContext;
                }

        public async Task<IList<Role>> GetAllRoles()
        {
            return await dbContext.AttandanceTable.ToListAsync();
        }

     
        public async Task<Role> GetRoleById(int id)
        {
            return await dbContext.AttandanceTable.FindAsync(id);
        }

       
        public async Task<int> AddRole(Role role)
        {
            await dbContext.AttandanceTable.AddAsync(role);   // ✅ correct table
            await dbContext.SaveChangesAsync();    // ✅ required
            return role.RoleID;
        }

        public async Task<int> UpdateRole(Role role)
        {
            dbContext.AttandanceTable.Update(role);
            return await dbContext.SaveChangesAsync();
        }

       
        public async Task<int> DeleteRole(int id)
        {
            var role = await dbContext.AttandanceTable.FindAsync(id);

            if (role == null)
                return 0;

            dbContext.AttandanceTable.Remove(role);
            return await dbContext.SaveChangesAsync();
        }
    }
}
