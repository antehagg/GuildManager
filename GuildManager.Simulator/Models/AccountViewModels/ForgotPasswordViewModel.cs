using System.ComponentModel.DataAnnotations;

namespace GuildManager.Simulator.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
