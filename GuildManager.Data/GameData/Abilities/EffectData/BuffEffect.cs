using System;
using System.Collections.Generic;
using System.Text;
using GuildManager.Data.GameData.Abilities;
using GuildManager.Data.GameObjects.Characters.Stats;

namespace GuildManager.Data.GameData.Abilities.EffectData
{
    public class BuffEffect : Effect
    {
        public BuffStats Stats { get; set; }

    }
}
