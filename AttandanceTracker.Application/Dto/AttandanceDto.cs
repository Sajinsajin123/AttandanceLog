using System;
using System.Collections.Generic;
using System.Text;

namespace AttandanceTracker.Application.Dto
{
    public class AttandanceDto
    {
        public int AttendanceID { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

        public string Course { get; set; }

        public int RecordedBy { get; set; }
    }
}
