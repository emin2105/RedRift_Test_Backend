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
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, Guid>
    {
        private readonly ApplicationDbContext context;

        public CreateUserHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Guid> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = request.Name,
                Id = Guid.NewGuid()
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user.Id;
        }
    }
}
