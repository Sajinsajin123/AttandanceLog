using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AttandanceTracker.Domain.Entities
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public String RoleName { get; set; }
        public String Description { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
