using MediatR;
using NumberGambling.Domain.Commands.GamblingCommands;
using NumberGambling.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NumberGambling.Domain.CommandHandlers.GamblingCommandHandler
{
    public class DeleteGamblingCommandHandler : IRequestHandler<DeleteGamblingCommand, bool>
    {
        public IGamblingRepository _GamblingRepository;


        public DeleteGamblingCommandHandler(IGamblingRepository GamblingRepository)
        {
            _GamblingRepository = GamblingRepository;
        }


        public async Task<bool> Handle(DeleteGamblingCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var result = await _GamblingRepository.DeleteGamblingAsync(id);

            return result;
        }
    }
}
