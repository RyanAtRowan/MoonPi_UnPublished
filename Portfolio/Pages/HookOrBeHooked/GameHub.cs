using Microsoft.AspNetCore.SignalR;

namespace Portfolio.Pages.HookOrBeHooked
{
    public class GameHub : Hub
    {
        private static string fishRole = null;
        private static string hookRole = null;

        public async Task AssignRole(string role, string connectionId)
        {
            if (role == "fish" && fishRole == null && connectionId != hookRole)
            {
                fishRole = connectionId;
            }
            else if (role == "hook" && hookRole == null && connectionId != fishRole)
            {
                hookRole = connectionId;
            }

            // Send the updated roles to all clients
            await Clients.All.SendAsync("UpdateRoles", fishRole, hookRole);
        }

        public async Task StartGameCountdown()
        {
            // Start game after a 3-second delay
            await Task.Delay(3000);
            await Clients.All.SendAsync("StartGame");
        }

        public async Task SendCurrentRoles(string connectionId)
        {
            await Clients.Client(connectionId).SendAsync("UpdateRoles", fishRole, hookRole);
        }

        public async Task UpdatePosition(string role, float x, float y)
        {
            await Clients.Others.SendAsync("ReceivePosition", role, x, y);
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            // Optionally send current positions of Fish and Hook to the new connection
        }
    }
}
