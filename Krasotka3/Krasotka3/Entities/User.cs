using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Krasotka3.Entities
{
    
    public partial class User
    {
        public int UserId { get; set; }
        public string UserSurname { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string UserPatronymic { get; set; } = null!;
        public string UserLogin { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public int UserRole { get; set; }

        public virtual Role UserRoleNavigation { get; set; } = null!;
        [NotMapped]
        public string FullName => $"{UserSurname} {UserName} {UserPatronymic}";

            
        
    }
}
