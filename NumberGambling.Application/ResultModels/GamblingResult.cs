using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGambling.Application.ResultModels
{
    public class GamblingResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public string Status { get; set; }
        public int TotalPoints { get; set; }
        public string PointChange { get; set; }
    }
}
