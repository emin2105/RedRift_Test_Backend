using MediatR;
using RedRift_Test_Backend.Data.Models;
using RedRift_Test_Backend.Logic.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRift_Test_Backend.Logic.Queries
{
    public record GetGameRoomsRequest : IRequest<List<GameRoom>>
    {
        public GetGameRoomsParams ParamdDto { get; }
        public GetGameRoomsRequest(GetGameRoomsParams paramdDto)
        {
            ParamdDto = paramdDto;
        }
    }
}
