using MediatR;
using RedRift_Test_Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRift_Test_Backend.Logic.Commands
{
    public record CreateGameRoomRequest : IRequest<Guid>
    {
        public User Host { get; }
        public CreateGameRoomRequest(User host)
        {
            Host = host;
        }
    }
}
