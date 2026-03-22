using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AttandanceTracker.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }
        [ForeignKey("RoleId")]
        public int RoleID { get; set; }

        public DateTime CreatedAt { get; set; }

        public Role Role { get; set; }

        public UserDetails UserDetails { get; set; }

        public ICollection<Attendance> Attendances { get; set; }

    }
}
