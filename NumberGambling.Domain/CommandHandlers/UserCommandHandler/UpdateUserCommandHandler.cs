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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        public IUserRepository _UserRepository;


        public UpdateUserCommandHandler(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }


        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var User = request.User;
            User.UpdatedAT = DateTime.Now;

            var result = await _UserRepository.UpdateUserAsync(User);

            return result;
        }
    }
}
