using Microsoft.Extensions.Configuration;
using NumberGambling.Application.Interfaces;
using NumberGambling.Application.ResultModels;
using NumberGambling.Application.ViewModels.Gambling;
using NumberGambling.Domain.Commands.GamblingCommands;
using NumberGambling.Domain.Core.Bus;
using NumberGambling.Domain.IRepository;
using NumberGambling.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGambling.Application.Services
{
    public class GamblingService : IGamblingService
    {
        private readonly IGamblingRepository _GamblingRepository;
        private readonly IMediatorHandler _bus;
        private readonly IUserService _userService;

        public GamblingService(IMediatorHandler bus, IGamblingRepository GamblingRepository, IUserService UserService)
        {
            _bus = bus;
            _GamblingRepository = GamblingRepository;
            _userService = UserService;
        }
        
        public async Task<bool> AddGamblingAsync(Gambling gambling)
        {

            var addGambling = new AddGamblingCommand(gambling);
            var result = await _bus.SendCommand(addGambling);
            return result;
            
        }

        
        private int GetRandomNumber() 
        {
            Random rand = new Random();
            //returns random number
            int number = rand.Next(0, 10);
            return number;
        }
        public async Task<GamblingResult> PerformGambling(User user, int points, int number)
        {
            GamblingResult result = new GamblingResult();
            // not enough points
            if (points > user.TotalPoints) 
            {
                result.Success = false;
                result.ErrorMessage = "Not enough points in the Account";
                return result;
            }
            int RandomNumber = GetRandomNumber();
            // Won
            if(number == RandomNumber) 
            {
                user.TotalPoints += (points * 9);
                await _userService.UpdateUserAsync(user);
                result.Success = true;
                result.Status = "Won";
                result.PointChange = "+" + (points * 9);
                result.TotalPoints = user.TotalPoints;
            }
            // Lose
            else 
            {
                user.TotalPoints -= points;
                await _userService.UpdateUserAsync(user);
                result.Success = true;
                result.Status = "Lose";
                result.PointChange = "-" +points;
                result.TotalPoints = user.TotalPoints;
            }
            // Add the gambling to the database
            Gambling gambling = new Gambling();
            gambling.UserId = user.Id;
            gambling.Amount = points;
            gambling.Status = result.Status == "Won" ? GamblingStatus.Win : GamblingStatus.Lose;

            var added = await AddGamblingAsync(gambling);
            if (!added) 
            {
                result = new GamblingResult();
                result.Success = false;
                result.ErrorMessage = "Failed to Save in the database";
                return result;
            }
            return result;
        }
        public async Task<IEnumerable<Gambling>> GetGamblingsAsync()
        {
            return await _GamblingRepository.GetGamblingsAsync();
        }

        public async Task<bool> UpdateGamblingAsync(Gambling Gambling)
        {
            var updateGambling = new UpdateGamblingCommand(Gambling);
            var result = await _bus.SendCommand(updateGambling);
            return result;
        }

        public async Task<bool> DeleteGamblingAsync(int id)
        {
            var deleteGambling = new DeleteGamblingCommand(id);
            var result = await _bus.SendCommand(deleteGambling);
            return result;
        }

        public async Task<Gambling> GetGamblingAsync(int id)
        {
            return await _GamblingRepository.GetGamblingAsync(id);
        }

        public Task<bool> AddGamblingAsync(GamblingRequest model)
        {
            throw new NotImplementedException();
        }
    }
}
