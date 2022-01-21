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

    public class AddGamblingCommandHandler : IRequestHandler<AddGamblingCommand, bool>
    {
        public IGamblingRepository _GamblingRepository;


        public AddGamblingCommandHandler(IGamblingRepository GamblingRepository)
        {
            _GamblingRepository = GamblingRepository;
        }


        public async Task<bool> Handle(AddGamblingCommand request, CancellationToken cancellationToken)
        {
            var Gambling = request.Gambling;
            Gambling.CreatedAT = DateTime.Now;

            var result = await _GamblingRepository.AddGamblingAsync(Gambling);

            return result;
        }
    }
}
