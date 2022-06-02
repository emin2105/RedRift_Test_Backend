using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RedRift_Test_Backend.Data.Context;
using RedRift_Test_Backend.Data.Models;
using RedRift_Test_Backend.Logic.RealTime.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRift_Test_Backend.Logic.Services
{
    public class GameSessionService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        public GameSessionService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public void StartTheGame(GameRoom gameRoom)
        {
            _ = Task.Run(async () =>
            {
                try
                {
                    using (var scope = serviceScopeFactory.CreateScope())
                    {
                        if (gameRoom.PlayerSessions.Count == 2)
                        {
                            bool gameOver = false;
                            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                            var hubContext = scope.ServiceProvider.GetRequiredService<IHubContext<GameRoomHub>>();
                            while (!gameOver)
                            {
                                var random = new Random();
                                foreach (var player in gameRoom.PlayerSessions)
                                {
                                    player.Health -= random.Next(1, 3);
                                    await hubContext.Clients.Group(gameRoom.Id.ToString())
                                        .SendAsync("Receive", $"{gameRoom.PlayerSessions[0].User.Name} Health({gameRoom.PlayerSessions[0].Health}) | {gameRoom.PlayerSessions[1].User.Name} Health({gameRoom.PlayerSessions[1].Health})");
                                    if (player.Health <= 0)
                                    {                                                                
                                        gameOver = true;
                                        break;
                                    }
                                    else
                                        Task.Delay(1000).Wait();
                                }
                                if (gameOver)
                                {
                                    gameRoom.IsOpen = false;
                                    gameRoom.PlayerSessions.First(p => p.Health > 0).Winner = true;
                                    await hubContext.Clients.Group(gameRoom.Id.ToString())
                                        .SendAsync("Receive", $"Player {gameRoom.PlayerSessions.First(p => p.Health > 0).User.Name} won!");

                                    dbContext.GameRooms.Update(gameRoom);
                                    await dbContext.SaveChangesAsync();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            });
        }
    }
}
