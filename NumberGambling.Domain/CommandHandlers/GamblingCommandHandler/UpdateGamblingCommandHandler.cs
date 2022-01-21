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
    public class UpdateGamblingCommandHandler : IRequestHandler<UpdateGamblingCommand, bool>
    {
        public IGamblingRepository _GamblingRepository;


        public UpdateGamblingCommandHandler(IGamblingRepository GamblingRepository)
        {
            _GamblingRepository = GamblingRepository;
        }


        public async Task<bool> Handle(UpdateGamblingCommand request, CancellationToken cancellationToken)
        {
            var Gambling = request.Gambling;

            var result = await _GamblingRepository.UpdateGamblingAsync(Gambling);

            return result;
        }
    }
}
