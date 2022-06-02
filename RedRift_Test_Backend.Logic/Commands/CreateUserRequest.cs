using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRift_Test_Backend.Logic.Commands
{
    public record CreateUserRequest : IRequest<Guid>
    {
        public string Name { get; }
        public CreateUserRequest(string name)
        {
            Name = name;
        }
    }
}
