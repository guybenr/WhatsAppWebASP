using Microsoft.AspNetCore.SignalR;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace webAPI.NET.Hubs
{
    public class ChatHub : Hub
    {
        /* function sends notify the user that changes has accured */
        public async Task Changed(string userId)
        {
            try
            {
                await Clients.Group(userId).SendAsync("changes recived");
            }
            catch (Exception ex)
            {
                return;
            }
        }

        /* function creating a group based on the userId argument */
        public async Task AddUser(string userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userId);
        }
    }
}
