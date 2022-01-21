using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGambling.Domain.Models
{
    public class User : BaseEntity
    {
        public int TotalPoints { get; set; }
        public IEnumerable<Gambling> Gamblings { get; set; }
    }
}
