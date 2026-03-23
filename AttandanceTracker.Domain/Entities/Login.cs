using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AttandanceTracker.Domain.Entities
{
    public class Login
    {
        [Key]
        public string EmailID { get; set; }
      
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
