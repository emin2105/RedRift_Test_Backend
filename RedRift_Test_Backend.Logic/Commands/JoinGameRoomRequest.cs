using MediatR;
using RedRift_Test_Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRift_Test_Backend.Logic.Commands
{
    public record JoinGameRoomRequest : IRequest<bool>
    {
        public User Player { get; }
        public GameRoom GameRoom { get; }

        public JoinGameRoomRequest(User player, GameRoom gameRoom)
        {
            Player = player;
            GameRoom = gameRoom;
        }
    }
}
