using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustOne.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace JustOne
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Number of players: ");
            var numPlayers = Console.ReadLine();
            var playerList = new List<Player>();
            try
            {
                for (var i = 0; i < int.Parse(numPlayers); i++)
                {
                    playerList.Add(new Player(i.ToString()));
                }
            } catch (Exception e)
            {
                Console.WriteLine("Error: ", e);
            }

            var newGame = new Game(playerList);
            Console.WriteLine(newGame);
            // CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
