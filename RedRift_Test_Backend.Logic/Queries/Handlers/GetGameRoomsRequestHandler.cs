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
    public class GetGameRoomsRequestHandler : IRequestHandler<GetGameRoomsRequest, List<GameRoom>>
    {
        private readonly ApplicationDbContext context;

        public GetGameRoomsRequestHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<GameRoom>> Handle(GetGameRoomsRequest request, CancellationToken cancellationToken)
        {
            var query = context.GameRooms.Include(r => r.Host).AsQueryable();
            if (request.ParamdDto.IsOpen.HasValue)
            {
                query = query.Where(r => r.IsOpen == request.ParamdDto.IsOpen);
            }

            return await query.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
