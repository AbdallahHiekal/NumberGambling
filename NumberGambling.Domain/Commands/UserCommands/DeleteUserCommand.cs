using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGambling.Domain.Commands.UserCommands
{
    public class DeleteUserCommand : UserCommand
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
