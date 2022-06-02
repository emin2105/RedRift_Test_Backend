using MediatR;
using Microsoft.EntityFrameworkCore;
using RedRift_Test_Backend.Data.Context;
using RedRift_Test_Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRift_Test_Backend.Logic.Queries.Handlers
{
    public class GetGameRoomRequestHandler : IRequestHandler<GetGameRoomRequest, GameRoom>
    {
        private readonly ApplicationDbContext context;

        public GetGameRoomRequestHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<GameRoom> Handle(GetGameRoomRequest request, CancellationToken cancellationToken)
        {
            var result = await context.GameRooms.Include(r => r.Host).Include(r => r.PlayerSessions).ThenInclude(p => p.User).FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken: cancellationToken);

            return result;
        }
    }
}
