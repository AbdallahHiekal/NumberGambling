using NumberGambling.Application.Interfaces;
using NumberGambling.Domain.Commands.UserCommands;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMediatorHandler _bus;

        public UserService(IMediatorHandler bus, IUserRepository UserRepository)
        {
            _bus = bus;
            _UserRepository = UserRepository;
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _UserRepository.GetUsersAsync();
        }
        public async Task<User> AddUserAsync()
        {
            User user = new User();
            var addUser = new AddUserCommand(user);
            var result = await _bus.SendCommand(addUser);
            if (result) return user;
            return null;
        }

        public async Task<bool> UpdateUserAsync(User User)
        {
            var updateUser = new UpdateUserCommand(User);
            var result = await _bus.SendCommand(updateUser);
            return result;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var deleteUser = new DeleteUserCommand(id);
            var result = await _bus.SendCommand(deleteUser);
            return result;
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _UserRepository.GetUserAsync(id);
        }
    }
}
