using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProject.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string AvailableDay { get; set; }
        public string AvailableTime_Start { get; set; }
        public string AvailableTime_End { get; set; }
        public string Education_Stage { get; set; }
        public int Level { get; set; }

        public List<Lesson> Lessons { get; set; }
    }
}
