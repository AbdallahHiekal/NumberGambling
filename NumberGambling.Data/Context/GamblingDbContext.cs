using Microsoft.EntityFrameworkCore;
using NumberGambling.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGambling.Infra.Data.Context
{
    public class GamblingDbContext: DbContext
    {
        public GamblingDbContext(DbContextOptions options): base(options)
        {
                
        }

        // DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Gambling> Gamblings { get; set; }

    }
}
