using NumberGambling.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGambling.Domain.Commands.UserCommands
{
    public class AddUserCommand : UserCommand
    {
        public AddUserCommand(User user)
        {
            User = user;
        }
    }
}
