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
    public class GamblingRepository : IGamblingRepository
    {
        private readonly GamblingDbContext _context;

        public GamblingRepository(GamblingDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddGamblingAsync(Gambling gambling)
        {
            try
            {
                await _context.AddAsync(gambling);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteGamblingAsync(int id)
        {
            try
            {
                var gambling = GetGamblingAsync(id);
                _context.Remove(gambling);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Gambling> GetGamblingAsync(int id)
        {
            return await _context.Gamblings.FindAsync(id);

        }

        public async Task<IEnumerable<Gambling>> GetGamblingsAsync()
        {
            return await _context.Gamblings.ToListAsync();
        }

        public async Task<bool> UpdateGamblingAsync(Gambling gambling)
        {
            try
            {
                _context.Update(gambling);
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
