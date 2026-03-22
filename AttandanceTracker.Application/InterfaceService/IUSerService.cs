using AttandanceTracker.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttandanceTracker.Application.InterfaceService
{
    public interface IUSerService
    {
        Task<int> AddUser(UserDto dto);

        Task<List<UserDto>> GetAllUsers();

        Task<UserDto> GetUserById(int id);

        Task<int> UpdateUser(int id, UserDto dto);

        Task<int> DeleteUser(int id);
    }
}
