using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRift_Test_Backend.Data.Models
{
    public class PlayerSession
    {
        public Guid Id { get; set; }
        public User? User { get; set; }
        public GameRoom? GameRoom { get; set; }
        public int Health { get; set; } = 10;
        public bool Winner { get; set; }
    }
}
