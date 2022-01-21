using NumberGambling.Application.ResultModels;
using NumberGambling.Application.ViewModels.Gambling;
using NumberGambling.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGambling.Application.Interfaces
{
    public interface IGamblingService
    {
        public Task<IEnumerable<Gambling>> GetGamblingsAsync();
        public Task<Gambling> GetGamblingAsync(int id);
        public Task<bool> AddGamblingAsync(Gambling gambling);
        public Task<bool> UpdateGamblingAsync(Gambling gambling);
        public Task<bool> DeleteGamblingAsync(int id);
        public Task<GamblingResult> PerformGambling(User user, int points, int number);
    }
}
