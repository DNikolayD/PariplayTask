using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Data.Entities
{
    public class UserDataEntity : IdentityUser
    {
        public ICollection<Team> Teams { get; set; }
    }
}
