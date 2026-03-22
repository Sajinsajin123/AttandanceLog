using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AttandanceTracker.Domain.Entities
{
    public class Attendance
    {
        [Key]
        public int AttendanceID { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

        public string Course { get; set; }

        public int RecordedBy { get; set; }
        public User User { get; set; }
        public User RecordedUser { get; set; }


    }
}
