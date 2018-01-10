using System;
using System.Collections.Generic;
using GuildManager.Api.Data;
using GuildManager.Api.Data.Contexts;
using GuildManager.Data.GameData.Abilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace GuildManager.Api.Controllers
{
    public class SkillController : Controller
    {
        public IServiceProvider Services;

        public SkillController(IServiceProvider services)
        {
            Services = services;
        }

        // GET api/PlayerCharacter
        [HttpGet]
        public IEnumerable<Skill> Get()
        {
            using (var context = Services.GetService<GuildManagerContext>())
            {
                try
                {
                    var skillContext = new SkillContext(context);
                    return skillContext.GetAllSkills();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        [HttpGet("{skillId}")]
        public Skill Skill(int skillId)
        {
            using (var context = Services.GetService<GuildManagerContext>())
            {
                try
                {
                    var skillContext = new SkillContext(context);
                    var skill = skillContext.GetSkillById(skillId);
                    return skill;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
