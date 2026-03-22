using AttandanceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AttandanceTracker.Domain.RepoInterface
{
    public interface IAttandanceRepository
    {
        Task<int> AddAsync(Attandance attandance);
        Task<List<Attandance>> GetAllAsync();
        Task<Attandance> GetByIdAsync(int id);
    }
}
