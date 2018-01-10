using System;
using System.Collections.Generic;
using System.Linq;
using GuildManager.Data.GameData.Abilities;
using GuildManager.Data.GameData.Items.Types;
using GuildManager.Data.GameData.Zones;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GuildManager.Api.Data.Contexts
{
    public class SkillContext
    {
        private readonly GuildManagerContext _context;
        public SkillContext(GuildManagerContext context)
        {
            _context = context;
        }

        public SkillContext(IServiceProvider service)
        {
            _context = service.GetService<GuildManagerContext>();
        }

        public Skill GetSkillById(int skillId)
        {
            var zone = _context.Skills.Include(w => w.Effects).First(w => w.Id == skillId);
            return zone;
        }

        public IEnumerable<Skill> GetAllSkills()
        {
            var skills = _context.Skills
                .Include(z => z.Effects)
                .ToArray();

            return skills;
        }
    }
}
