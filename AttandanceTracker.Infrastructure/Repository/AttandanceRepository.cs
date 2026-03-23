using AttandanceTracker.Application.Dto;
using AttandanceTracker.Domain.Entities;
using AttandanceTracker.Domain.RepoInterface;
using AttandanceTracker.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AttandanceTracker.Infrastructure.Repository
{
    public class AttandanceRepository:IAttandanceRepository
    {
        private readonly AttandanceTrackerDbContext _context;

        public AttandanceRepository(AttandanceTrackerDbContext context)
        {
            _context = context;
        }




        public async Task<int> AddAttandanceAsync(Attendance attandance)
        {
            await _context.AttandanceCheck.AddAsync(attandance);
            await _context.SaveChangesAsync();
            return attandance.AttendanceID;
        }

        public async Task<List<Attendance>> GetAllAttandanceAsync()
        {
            return await _context.AttandanceCheck.ToListAsync();
        }

        public async Task<Attendance> GetByIdAsync(int id)
        {
            return await _context.AttandanceCheck.FindAsync(id);
        }
        public async Task <int>UpdateAttandance(Attendance attandance )
        {
            _context.AttandanceCheck.Update(attandance);
            await _context.SaveChangesAsync();
            return attandance.AttendanceID;
        }
        public async Task<int> DeleteAttandance(int id)
        {
            var data = await _context.AttandanceCheck.FindAsync(id);

            if (data == null)
                return 0;

            _context.AttandanceCheck.Remove(data);
            await _context.SaveChangesAsync();

            return 1;
        }
    }
}
