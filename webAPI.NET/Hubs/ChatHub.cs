using Microsoft.AspNetCore.SignalR;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace webAPI.NET.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Changed(string message)
        {
            await Clients.All.SendAsync("changed", message);
        }
    }
}
