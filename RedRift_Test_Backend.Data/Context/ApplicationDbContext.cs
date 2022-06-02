using Microsoft.EntityFrameworkCore;
using RedRift_Test_Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRift_Test_Backend.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User>? Users => Set<User>();
        public DbSet<PlayerSession>? PlayerSessions => Set<PlayerSession>();
        public DbSet<GameRoom>? GameRooms => Set<GameRoom>();
    }
}
