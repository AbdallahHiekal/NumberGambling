using MediatR;
using NumberGambling.Domain.Commands.UserCommands;
using NumberGambling.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NumberGambling.Domain.CommandHandlers.UserCommandHandler
{

    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, bool>
    {
        public IUserRepository _UserRepository;


        public AddUserCommandHandler(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }


        public async Task<bool> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var User = request.User;
            User.TotalPoints = 10000;
            User.CreatedAT = DateTime.Now;

            var result = await _UserRepository.AddUserAsync(User);

            return result;
        }
    }
}
