using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StudentExt
    {
        public Student Student { get; set; }
        public StudentClass StudentClass { get; set; }
        public Attendance Attendance { get; set; }
        public ScoreList ScoreList { get; set; }
    }
}
