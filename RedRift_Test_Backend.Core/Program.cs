using MediatR;
using Microsoft.EntityFrameworkCore;
using RedRift_Test_Backend.Data.Context;
using RedRift_Test_Backend.Logic.RealTime.SignalR;
using RedRift_Test_Backend.Logic.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = @"Server=db;Database=redrift-test;User Id=sa;Password=zfC5h0uZ;MultipleActiveResultSets=true;Integrated Security=false;TrustServerCertificate=true";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connection);
});

builder.Services.AddMediatR(typeof(GameSessionService).Assembly);
builder.Services.AddScoped<GameSessionService>();
builder.Services.AddSignalR();
builder.Services.AddRouting();
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
            builder =>
            {
                builder.AllowAnyHeader()
                       .AllowAnyMethod()
                       .SetIsOriginAllowed((host) => true)
                       .AllowCredentials();
            }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();
app.MapHub<GameRoomHub>("/gameroom");

app.UseHttpsRedirection();

app.MapControllers();
app.UseCors("CorsPolicy");

InitializeDatabase(app);
app.Run();

void InitializeDatabase(IApplicationBuilder app)
{
    using (var scope = app?.ApplicationServices?.GetService<IServiceScopeFactory>()?.CreateScope())
    {
        scope?.ServiceProvider?.GetRequiredService<ApplicationDbContext>()?.Database?.Migrate();
    }
}
