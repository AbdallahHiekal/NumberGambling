using NumberGambling.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGambling.Domain.Commands.UserCommands
{
    public class UpdateUserCommand : UserCommand
    {
        public UpdateUserCommand(User user)
        {
            User = user;
        }
    }
}
