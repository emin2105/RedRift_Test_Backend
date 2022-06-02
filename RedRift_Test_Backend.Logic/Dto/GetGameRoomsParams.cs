using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRift_Test_Backend.Logic.Dto
{
    public record GetGameRoomsParams
    {
        public Guid? Id { get; set; }
        public bool? IsOpen { get; set; }
        public Guid? Host { get; set; }
    }
}
