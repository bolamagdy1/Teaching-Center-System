using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProject.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [ForeignKey("Hall")]
        public int HallId { get; set; }
        public Hall Hall { get; set; }
    }
}
