using NumberGambling.Utility.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGambling.Application.ViewModels.Gambling
{
    public class GamblingRequest
    {
        [PositiveNumber]
        public int Points { get; set; }
        [Range(0, 9, ErrorMessage = "Number Must be between 0 to 9")]
        public int Number { get; set; }
        public int UserId { get; set; }
    }
}
