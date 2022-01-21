using NumberGambling.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGambling.Application.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetUsersAsync();
        public Task<User> GetUserAsync(int id);
        public Task<User> AddUserAsync();
        public Task<bool> UpdateUserAsync(User User);
        public Task<bool> DeleteUserAsync(int id);
    }
}
