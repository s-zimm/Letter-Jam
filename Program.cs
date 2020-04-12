using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetterJam.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LetterJam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // var numPlayers = 5;
            // Console.WriteLine("Number of players: " + numPlayers);
            // var playerList = new List<Player>();

            // for (var i = 0; i < numPlayers; i++)
            // {
            //     playerList.Add(new Player(i.ToString()));
            // }

            // Console.WriteLine("Player list: " + playerList);
            // var newGame = new Game(playerList);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
