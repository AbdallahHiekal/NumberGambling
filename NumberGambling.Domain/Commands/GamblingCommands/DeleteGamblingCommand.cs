using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGambling.Domain.Commands.GamblingCommands
{
    public class DeleteGamblingCommand : GamblingCommand
    {
        public DeleteGamblingCommand(int id)
        {
            Id = id;
        }
    }
}
