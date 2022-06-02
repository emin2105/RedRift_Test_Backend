using MediatR;
using RedRift_Test_Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRift_Test_Backend.Logic.Queries
{
    public record GetGameRoomRequest : IRequest<GameRoom>
    {
        public Guid Id { get; }
        public GetGameRoomRequest(Guid id)
        {
            Id = id;
        }
    }
}
