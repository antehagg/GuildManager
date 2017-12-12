using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildManager.Data.GameData.Characters;
using GuildManager.Data.GameObjects.Characters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GuildManager.Api.Data.Contexts
{
    public class MonsterContext
    {
        private readonly GuildManagerContext _context;
        public MonsterContext(GuildManagerContext context)
        {
            _context = context;
        }

        public MonsterContext(IServiceProvider service)
        {
            _context = service.GetService<GuildManagerContext>();
        }

        public DbMonster[] GetAllMonsters()
        {
            var monsters = _context.Monsters
                .Include(m => m.MonsterBaseResources)
                .Include(m => m.Class).ThenInclude(c => c.BaseStats)
                .Include(m => m.Class).ThenInclude(c => c.BaseResources)
                .Include(m => m.Inventory)
                .ToArray();

            return monsters;
        }

        public DbMonster GetMonsterById(int monsterId)
        {
            var monster = _context.Monsters
                .Include(m => m.MonsterBaseResources)
                .Include(m => m.Class).ThenInclude(c => c.BaseStats)
                .Include(m => m.Class).ThenInclude(c => c.BaseResources)
                .Include(m => m.Inventory)
                .First(m => m.Id == monsterId);

            return monster;
        }
    }
}
