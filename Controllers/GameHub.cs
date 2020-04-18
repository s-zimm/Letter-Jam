using System;
using System.Linq;
using System.Threading.Tasks;
using LetterJam.Models;
using Microsoft.AspNetCore.SignalR;

namespace LetterJam.Hubs
{
    public class GameHub : Hub
    {

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var username = httpContext.Request.Query["username"].ToString();
            var roomCode = httpContext.Request.Query["roomcode"].ToString();
            var gameRoomCode = "";

            if (roomCode != "")
            {
                gameRoomCode = roomCode;
            } 
            else
            {
                gameRoomCode = RandomString(8);
            }
            var newUser = new Player(username);
            Context.Items[gameRoomCode] = newUser;
            await SendRoomCode(gameRoomCode, Context);
            await Groups.AddToGroupAsync(Context.ConnectionId, gameRoomCode);
            await base.OnConnectedAsync();
        }

        public async Task AddToGroup(string groupName, string username)
        {
            var newUser = new Player(username);
            Context.Items["Player"] = newUser;
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public static string RandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}