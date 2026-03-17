using AttandanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttandanceTracker.Infrastructure.DBContext
{
    public class AttandanceTrackerDbContext:DbContext
    {
        public AttandanceTrackerDbContext(DbContextOptions<AttandanceTrackerDbContext>option):base(option) { }
        public DbSet<Role> AttandanceTable { get; set; }
        public DbSet<User> AttandanceUser { get; set; }
        public DbSet<Attendance> AttandanceCheck {  get; set; }
        public DbSet<UserDetails> AttandanceDetailsDetails { get;set; }
    }
    
}
