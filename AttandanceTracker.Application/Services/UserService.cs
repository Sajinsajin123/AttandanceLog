using AttandanceTracker.Application.Dto;
using AttandanceTracker.Application.InterfaceService;
using AttandanceTracker.Domain.Entities;
using AttandanceTracker.Domain.RepoInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttandanceTracker.Application.Services
{
    public class UserService:IUSerService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<int> AddUser(UserDto dto)
        {
            var user = new User
            {
                UserName = dto.UserName,
                PasswordHash = dto.PasswordHash,
                Email = dto.Email,
                RoleID = dto.RoleID,
                CreatedAt = DateTime.Now,

                UserDetails = new UserDetails   // ✅ THIS SAVES IN SECOND TABLE
                {
                    FullName = dto.FullName,
                    DOB = dto.DOB,
                    Gender = dto.Gender,
                    PhoneNumber = dto.PhoneNumber,
                    Address = dto.Address,
                    Department = dto.Department,
                    Year = dto.Year
                }
            };

            return await userRepository.AddUser(user);
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var users = await userRepository.GetAllUsers();

            return users.Select(u => new UserDto
            {
                UserName = u.UserName,
                Email = u.Email,
                RoleID = u.RoleID,
                FullName = u.UserDetails?.FullName
            }).ToList();
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var u = await userRepository.GetUserById(id);

            if (u == null) return null;

            return new UserDto
            {
                UserName = u.UserName,
                Email = u.Email,
                RoleID = u.RoleID,
                FullName = u.UserDetails?.FullName
            };
        }

        public async Task<int> UpdateUser(int id, UserDto dto)
        {
            var user = await userRepository.GetUserById(id);

            if (user == null) return 0;

            user.UserName = dto.UserName;
            user.Email = dto.Email;

            user.UserDetails.FullName = dto.FullName;

            return await userRepository.UpdateUser(user);
        }

        public async Task<int> DeleteUser(int id)
        {
            return await userRepository.DeleteUser(id);
        }

    }
}
