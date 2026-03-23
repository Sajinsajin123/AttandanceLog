using AttandanceTracker.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttandanceTracker.Application.InterfaceService
{
    public interface IAttandanceService
    {
        Task<IList<AttandanceDto>> GetAllAttandanceAsync();
        Task<AttandanceDto> GetAttandanceById(int id);
        Task<int> AddAttandanceAsync(AttandanceDto attandancedto);
        Task<int> UpdateAttandanceAsync(AttandanceDto attandancedto);
        Task<int> DeleteAttandanceAsync(int id);
    }
}
