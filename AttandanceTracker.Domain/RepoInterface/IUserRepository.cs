using AttandanceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AttandanceTracker.Domain.RepoInterface
{
    public interface IUserRepository
    {
        Task<int> AddUser(User user);

        Task<List<User>> GetAllUsers();

        Task<User> GetUserById(int id);

        Task<int> UpdateUser(User user);

        Task<int> DeleteUser(int id);


    }
}
