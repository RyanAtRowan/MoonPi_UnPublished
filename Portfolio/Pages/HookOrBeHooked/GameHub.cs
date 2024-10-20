using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;

namespace Portfolio.Pages.HookOrBeHooked
{
    // ======================================================
    // GameHub: Manages player roles, spectators, and real-time game state using SignalR.
    // ======================================================
    public class GameHub : Hub
    {
        // Static variables to track current player roles and spectators
        private static string fishRole = null;  // Connection ID of the player assigned as Fish
        private static string hookRole = null;  // Connection ID of the player assigned as Hook
        private static List<string> spectators = new List<string>();  // List of spectator connection IDs


        // ======================================================
        // ROLE ASSIGNMENT & MANAGEMENT
        // ======================================================

        // Assigns a spectator role to the client if neither Fish nor Hook is available.
        public async Task AssignSpectator(string connectionId)
        {
            spectators.Add(connectionId);  // Add the connection ID to the spectators list
            await Clients.All.SendAsync("UpdateRoles", fishRole, hookRole, spectators);  // Update roles for all clients
            //await Clients.All.SendAsync("HowToPlay");
            await StartGameCountdown();  // Start the game countdown
        }

        // Assigns the requested role (Fish or Hook) to a client if available.
        public async Task AssignRole(string role, string connectionId)
        {
            if (role == "fish" && fishRole == null && connectionId != hookRole)
            {
                Console.WriteLine("Fish Role Assigned..");
                fishRole = connectionId;  // Assign Fish role to the client
            }
            else if (role == "hook" && hookRole == null && connectionId != fishRole)
            {
                hookRole = connectionId;  // Assign Hook role to the client
            }
            else
            {
                spectators.Add(connectionId);  // Add client as a spectator if both roles are taken
            }

            // Send the updated roles to all clients
            await Clients.All.SendAsync("UpdateRoles", fishRole, hookRole, spectators);

            // Move all clients to the How To Play once the fish and hook roles are assigned
            if (fishRole != null && hookRole != null)
            {
                await Clients.All.SendAsync("HowToPlay");
            }
        }


        // ======================================================
        // GAME MANAGEMENT METHODS
        // ======================================================

        // Starts the game countdown after a 3-second delay
        public async Task StartGameCountdown()
        {
            Console.WriteLine("Countdown Started...");
            await Task.Delay(3000);  // Delay the game start by 3 seconds
            await Clients.All.SendAsync("StartGame");  // Notify all clients to start the game
        }

        // Notify all clients that the Hook player has won
        public async Task HookWins()
        {
            await Clients.All.SendAsync("HookWins");
        }

        // Notify all clients that the Fish player has won
        public async Task FishWins()
        {
            await Clients.All.SendAsync("FishWins");
        }

        // Sends the current roles to the newly connected client
        public async Task SendCurrentRoles(string connectionId)
        {
            await Clients.Client(connectionId).SendAsync("UpdateRoles", fishRole, hookRole, spectators);
        }

        // Updates the position of Fish or Hook and sends it to all other clients
        public async Task UpdatePosition(string role, float x, float y)
        {
            await Clients.Others.SendAsync("ReceivePosition", role, x, y);  // Broadcast the position to all other clients
        }

        // Creates trash at a given size, speed, and Y position and sends the event to all clients
        public async Task CreateTrash(int size, int speed, float y)
        {
            await Clients.All.SendAsync("spawnTrashEvent", size, speed, y);  // Broadcast the trash spawn event to all clients
        }

        // ======================================================
        // CONNECTION MANAGEMENT
        // ======================================================

        // Handles logic when a client connects to the hub
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            // Optionally, you could send the current positions of Fish and Hook to the new connection
        }

        // Handles logic when a client disconnects from the hub
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            // Remove the disconnected client from their role or spectator list
            if (Context.ConnectionId == fishRole)
            {
                fishRole = null;  // Clear Fish role
            }
            else if (Context.ConnectionId == hookRole)
            {
                hookRole = null;  // Clear Hook role
            }
            else
            {
                spectators.Remove(Context.ConnectionId);  // Remove from spectators list
            }

            // Update the roles and spectators for all clients
            await Clients.All.SendAsync("UpdateRoles", fishRole, hookRole, spectators);
            await base.OnDisconnectedAsync(exception);  // Ensure the base disconnect logic is executed
        }

        // Resets all roles and spectators after a game ends or restarts
        public async Task ResetRoles()
        {
            // Reset roles and clear spectators list
            fishRole = null;
            hookRole = null;
            spectators.Clear();

            // Notify all clients that the roles have been reset
            await Clients.All.SendAsync("UpdateRoles", fishRole, hookRole, spectators);

            // Notify clients to clear their local storage (if necessary)
            await Clients.All.SendAsync("ClearLocalStorage");
        }
    }
}
