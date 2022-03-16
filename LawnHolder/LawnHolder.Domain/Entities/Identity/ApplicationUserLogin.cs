﻿using Microsoft.AspNetCore.Identity;

namespace LawnHolder.Domain.Entities.Identity
{
    public class ApplicationUserLogin : IdentityUserLogin<string>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
