using NumberGambling.Domain.Core.Commands;
using NumberGambling.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGambling.Domain.Commands.GamblingCommands
{
    public class GamblingCommand : Command
    {
        public int Id { get; set; }
        public Gambling Gambling { get; set; }
    }
}
