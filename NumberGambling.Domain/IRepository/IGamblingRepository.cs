using NumberGambling.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGambling.Domain.IRepository
{
    public interface IGamblingRepository
    {
        public Task<IEnumerable<Gambling>> GetGamblingsAsync();
        public Task<Gambling> GetGamblingAsync(int id);
        public Task<bool> AddGamblingAsync(Gambling gambling);
        public Task<bool> UpdateGamblingAsync(Gambling gambling);
        public Task<bool> DeleteGamblingAsync(int id);
    }
}
