using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager.Data.Users
{
    public class User : IdentityUser
    {
        public DateTime JoinDate { get; set; }
    }
}
