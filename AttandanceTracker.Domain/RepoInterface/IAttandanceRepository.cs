using AttandanceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AttandanceTracker.Domain.RepoInterface
{
    public interface IAttandanceRepository
    {
        Task<int> AddAttandanceAsync(Attendance attandance);
        Task<List<Attendance>> GetAllAttandanceAsync();
        Task<Attendance> GetByIdAsync(int id);
        Task<int> UpdateAttandance(Attendance attandance);
        Task<int> DeleteAttandance(int id);

    }
}

           
   
