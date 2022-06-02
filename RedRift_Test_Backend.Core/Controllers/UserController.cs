using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedRift_Test_Backend.Logic.Commands;
using RedRift_Test_Backend.Logic.Queries;

namespace RedRift_Test_Backend.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(string name)
        {
            var id = await mediator.Send(new CreateUserRequest(name));
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await mediator.Send(new GetUserRequest(id));
            return Ok(user);
        }
    }
}
