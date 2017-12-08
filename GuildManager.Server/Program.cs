using System;
using GuildManager.Data.GameData.Characters;
using Newtonsoft.Json;

namespace GuildManager.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var pc = new DbPlayerCharacter
            {
                Name = "Vexing"
            };

            var json = JsonConvert.SerializeObject(pc);
        }
    }
}
