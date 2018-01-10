using System.ComponentModel.DataAnnotations;

namespace GuildManager.Simulator.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
