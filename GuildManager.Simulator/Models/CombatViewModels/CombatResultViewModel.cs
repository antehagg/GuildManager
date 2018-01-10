using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GuildManager.Server.GameEngine.GameObjects.Characters;
using GuildManager.Server.GameEngine.GameObjects.Groups;

namespace GuildManager.Simulator.Models.CombatViewModels
{
    public class CombatResultViewModel
    {
        [Required]
        [Display(Name = "Attackers")]
        public CharacterGroup Attackers { get; set; }

        [Required]
        [Display(Name = "Defenders")]
        public CharacterGroup Defenders { get; set; }

        [Required]
        [Display(Name = "Combat Members")]
        public List<ICharacterObject> CombatMembers { get; set; }
    }
}
