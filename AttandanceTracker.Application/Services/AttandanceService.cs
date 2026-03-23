using AttandanceTracker.Application.Dto;
using AttandanceTracker.Application.InterfaceService;
using AttandanceTracker.Domain.Entities;
using AttandanceTracker.Domain.RepoInterface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;



namespace AttandanceTracker.Application.Services
{
    public class AttandanceService : IAttandanceService
    {
        private readonly IAttandanceRepository repository;
        private readonly IMapper mapper;

        public AttandanceService(IAttandanceRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }


        // ✅ CREATE
        public async Task<int> AddAttandanceAsync(AttandanceDto attandancedto)
        {
            var entity = mapper.Map<Attendance>(attandancedto);
            return await repository.AddAttandanceAsync(entity);
        }

        // ✅ DELETE
        public async Task<int> DeleteAttandanceAsync(int id)
        {
            try
            {
                var existing = await repository.GetByIdAsync(id);

                if (existing == null)
                    return 0;

                return await repository.DeleteAttandance(id);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        // ✅ READ ALL
        public async Task<IList<AttandanceDto>> GetAllAttandanceAsync()
        {
            var data = await repository.GetAllAttandanceAsync();
            return mapper.Map<List<AttandanceDto>>(data);
        }

        // ✅ READ BY ID
        public async Task<AttandanceDto> GetAttandanceById(int id)
        {
            var data = await repository.GetByIdAsync(id);
            return mapper.Map<AttandanceDto>(data);
        }

        // ✅ UPDATE
        public async Task<int> UpdateAttandanceAsync(AttandanceDto attandancedto)
        {
            try
            {
                var existing = await repository.GetByIdAsync(attandancedto.AttendanceID);

                if (existing == null)
                    return 0;

                var entity = mapper.Map<Attendance>(attandancedto);

                return await repository.UpdateAttandance(entity);
                
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
