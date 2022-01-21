using NumberGambling.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGambling.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime TimeSpan { get; protected set; }
        protected Command()
        {
            TimeSpan = DateTime.Now;
        }
    }
}
