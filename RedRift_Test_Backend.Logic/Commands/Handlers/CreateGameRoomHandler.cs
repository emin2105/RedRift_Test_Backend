using MediatR;
using RedRift_Test_Backend.Data.Context;
using RedRift_Test_Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRift_Test_Backend.Logic.Commands.Handlers
{
    public class CreateGameRoomHandler : IRequestHandler<CreateGameRoomRequest, Guid>
    {
        private readonly ApplicationDbContext context;

        public CreateGameRoomHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Guid> Handle(CreateGameRoomRequest request, CancellationToken cancellationToken)
        {
            var room = new GameRoom
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTime.UtcNow,
                Host = request.Host,
                IsOpen = true,
                PlayerSessions = new List<PlayerSession>()
            };
            room.PlayerSessions.Add(new PlayerSession { User = request.Host, GameRoom = room });

            context.GameRooms.Add(room);
            await context.SaveChangesAsync();

            return room.Id;
        }
    }
}
