using System;
using GuildManager.Data.GameObjects.Characters;
using Newtonsoft.Json;

namespace GuildManager.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var pc = new PlayerCharacter
            {
                Name = "Vexing"
            };

            var json = JsonConvert.SerializeObject(pc);
        }
    }
}
