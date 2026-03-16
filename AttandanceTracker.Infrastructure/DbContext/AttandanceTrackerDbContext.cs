using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttandanceTracker.Infrastructure.DBContext
{
    public class AttandanceTrackerDbContext:DbContext
    {
        public AttandanceTrackerDbContext(DbContextOptions<AttandanceTrackerDbContext>option):base(option) { }
    }
}
