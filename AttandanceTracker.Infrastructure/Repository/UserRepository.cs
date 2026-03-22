using AttandanceTracker.Domain.Entities;
using AttandanceTracker.Domain.RepoInterface;
using Microsoft.EntityFrameworkCore;
using AttandanceTracker.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttandanceTracker.Infrastructure.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly AttandanceTrackerDbContext dbContext;
        public UserRepository(AttandanceTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> AddUser(User user)
        {
            await dbContext.AttandanceUser.AddAsync(user);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await dbContext.AttandanceUser
                .Include(u => u.UserDetails)
                .ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await dbContext.AttandanceUser
                .Include(u => u.UserDetails)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<int> UpdateUser(User user)
        {
            dbContext.AttandanceUser.Update(user);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteUser(int id)
        {
            var user = await dbContext.AttandanceUser.FindAsync(id);
            if (user == null) return 0;

            dbContext.AttandanceUser.Remove(user);
            return await dbContext.SaveChangesAsync();
        }

    }
}
