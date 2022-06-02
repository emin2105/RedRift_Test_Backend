using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRift_Test_Backend.Data.Models
{
    public class GameRoom
    {
        public Guid Id { get; set; }
        public bool IsOpen { get; set; }
        public User? Host { get; set; }
        public List<PlayerSession> PlayerSessions { get; set; } = new List<PlayerSession>();
        public DateTime CreateDate { get; set; }        
    }
}
