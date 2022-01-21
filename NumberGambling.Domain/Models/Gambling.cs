using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGambling.Domain.Models
{
    public class Gambling : BaseEntity
    {
        public int Amount { get; set; }
        public GamblingStatus Status { get; set; }
        //Relation with user Entity
        public int UserId { get; set; }
        public User User { get; set; }
    }
    public enum GamblingStatus
    {
        Win = 1,
        Lose
    }
}
