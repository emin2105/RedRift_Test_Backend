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
    public class GetUserHandler : IRequestHandler<GetUserRequest, User>
    {
        private readonly ApplicationDbContext context;

        public GetUserHandler(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<User> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == request.Id);
            return user;
        }
    }
}
