using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRift_Test_Backend.Logic.RealTime.SignalR
{
    public class GameRoomHub : Hub
    {
        public async Task Enter(string userId, string roomId)
        {
            if (!string.IsNullOrEmpty(roomId) && !string.IsNullOrEmpty(userId))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
                await Clients.Group(roomId).SendAsync("Notify", $"{userId} is entered");
            }
        }

        public async Task Send(string message, string groupName)
        {
            await Clients.Group(groupName).SendAsync("Receive", message);
        }
    }
}
