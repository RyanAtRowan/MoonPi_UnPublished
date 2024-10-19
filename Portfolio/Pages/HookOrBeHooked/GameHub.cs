using Microsoft.AspNetCore.SignalR;

namespace Portfolio.Pages.HookOrBeHooked
{
    public class GameHub : Hub
    {
        private static string fishRole = null;
        private static string hookRole = null;
        private static List<string> spectators = new List<string>(); // Track spectator connections

        public async Task AssignRole(string role, string connectionId)
        {
            if (role == "fish" && fishRole == null) /*&& connectionId != hookRole*/
            {
                Console.WriteLine("Fish Role Assigned..");
                fishRole = connectionId;
            }
            else if (role == "hook" && hookRole == null) /*&& connectionId != fishRole*/
            {
                hookRole = connectionId;
            }
            else
            {
                spectators.Add(connectionId);
            }

            // Send the updated roles to all clients
            await Clients.All.SendAsync("UpdateRoles", fishRole, hookRole, spectators);

            // Check if both roles are assigned and start the game countdown
            if (fishRole != null && hookRole != null)
            {
                Console.WriteLine("Both roles assigned. Starting countdown...");
                await StartGameCountdown(); 
            }
        }

        // GAME MANAGEMENT

        public async Task StartGameCountdown()
        {
            Console.WriteLine("Countdown Started...");
            // Start game after a 3-second delay
            await Task.Delay(3000);
            await Clients.All.SendAsync("StartGame");
        }

        public async Task HookWins()
        {
            await Clients.All.SendAsync("HookWins");
        }

        public async Task SendCurrentRoles(string connectionId)
        {
            await Clients.Client(connectionId).SendAsync("UpdateRoles", fishRole, hookRole, spectators);
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

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            // Remove players or spectators when they disconnect
            if (Context.ConnectionId == fishRole)
            {
                fishRole = null;
            }
            else if (Context.ConnectionId == hookRole)
            {
                hookRole = null;
            }
            else
            {
                spectators.Remove(Context.ConnectionId); // Remove from spectators list
            }
            // Update the roles and spectators for all clients
            await Clients.All.SendAsync("UpdateRoles", fishRole, hookRole, spectators);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task ResetRoles()
        {
            fishRole = null;
            hookRole = null;
            spectators.Clear();


            // Notify all clients that the roles have been reset
            await Clients.All.SendAsync("UpdateRoles", fishRole, hookRole, spectators);

            // Notify clients to clear local storage
            await Clients.All.SendAsync("ClearLocalStorage");
        }
    }
}
