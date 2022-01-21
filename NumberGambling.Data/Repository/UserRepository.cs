using Microsoft.EntityFrameworkCore;
using NumberGambling.Domain.IRepository;
using NumberGambling.Domain.Models;
using NumberGambling.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGambling.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly GamblingDbContext _context;

        public UserRepository(GamblingDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddUserAsync(User user)
        {
            try
            {
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var user = GetUserAsync(id);
                _context.Remove(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _context.Users.FindAsync(id);

        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            try
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
