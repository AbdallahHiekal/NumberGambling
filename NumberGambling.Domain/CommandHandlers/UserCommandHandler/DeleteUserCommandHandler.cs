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
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        public IUserRepository _UserRepository;


        public DeleteUserCommandHandler(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }


        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var result = await _UserRepository.DeleteUserAsync(id);

            return result;
        }
    }
}
