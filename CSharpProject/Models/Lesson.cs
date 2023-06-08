using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProject.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string Day { get; set; }
        public string Start_Time { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [ForeignKey("Hall")]
        public int HallId { get; set; }
        public Hall Hall { get; set; }
        public int Capacity { get; set; }

        public List<Student> students { get; set; }
    }
}
