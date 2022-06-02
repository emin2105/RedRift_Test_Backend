using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedRift_Test_Backend.Logic.Commands;
using RedRift_Test_Backend.Logic.Dto;
using RedRift_Test_Backend.Logic.Queries;

namespace RedRift_Test_Backend.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameRoomController : ControllerBase
    {
        private readonly IMediator mediator;

        public GameRoomController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await mediator.Send(new GetGameRoomRequest(id));
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("list")]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new GetGameRoomsRequest(new GetGameRoomsParams { IsOpen = true }));
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Guid userId)
        {
            var host = await mediator.Send(new GetUserRequest(userId));
            if (host != null)
            {
                var result = await mediator.Send(new CreateGameRoomRequest(host));
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("join")]
        public async Task<IActionResult> Join(Guid roomId, Guid userId)
        {
            var player = await mediator.Send(new GetUserRequest(userId));
            if (player != null)
            {
                var room = await mediator.Send(new GetGameRoomRequest(roomId));
                if (room != null)
                {
                    var result = await mediator.Send(new JoinGameRoomRequest(player, room));
                    return result ? Ok() : BadRequest();
                }
            }
            return BadRequest();
        }
    }
}
