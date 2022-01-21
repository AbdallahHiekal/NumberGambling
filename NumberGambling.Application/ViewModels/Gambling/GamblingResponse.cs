using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGambling.Application.ViewModels.Gambling
{
    public class GamblingResponse
    {
        public int Account { get; set; }
        public string Status { get; set; }
        public string Points { get; set; }
        public int UserId { get; set; }
    }
}
