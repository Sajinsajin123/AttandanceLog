using AttandanceTracker.Application.Dto;
using AttandanceTracker.Domain.Entities;
using AttandanceTracker.Domain.RepoInterface;
using AttandanceTracker.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttandanceTracker.Infrastructure.Repository
{
    public class AttandanceRepository:IAttandanceRepository
    {
        private readonly AttandanceTrackerDbContext _context;

        public AttandanceRepository(AttandanceTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(AttandanceDto attandance)
        {
            await _context.AttandanceCheck.AddAsync(attandance);
            await _context.SaveChangesAsync();
            return attandance.AttendanceID;
        }

        public async Task<List<AttandanceDto>> GetAllAsync()
        {
            return await _context.AttandanceCheck.ToListAsync();
        }

        public async Task<AttandanceDto> GetByIdAsync(int id)
        {
            return await _context.AttandanceCheck.FindAsync(id);
        }
    }
}
