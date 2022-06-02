using MediatR;
using RedRift_Test_Backend.Data.Context;
using RedRift_Test_Backend.Data.Models;
using RedRift_Test_Backend.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRift_Test_Backend.Logic.Commands.Handlers
{
    public class JoinGameRoomHandler : IRequestHandler<JoinGameRoomRequest, bool>
    {
        private readonly ApplicationDbContext context;
        private readonly GameSessionService gameSessionService;

        public JoinGameRoomHandler(ApplicationDbContext context, GameSessionService gameSessionService)
        {
            this.context = context;
            this.gameSessionService = gameSessionService;
        }
        public async Task<bool> Handle(JoinGameRoomRequest request, CancellationToken cancellationToken)
        {
            var room = request.GameRoom;
            var player = request.Player;
            if (room != null && room.IsOpen && room.PlayerSessions.Count == 1 && !room.PlayerSessions.Any(p => p.User.Id == player.Id))
            {
                var playerSession = new PlayerSession
                {
                    GameRoom = room,
                    Health = 10,
                    Id = Guid.NewGuid(),
                    User = player
                };
                room.PlayerSessions.Add(playerSession);
                context.PlayerSessions.Add(playerSession);
                context.GameRooms.Update(room);
                await context.SaveChangesAsync();
                gameSessionService.StartTheGame(room);
                return true;
            }
            return false;

        }
    }
}
