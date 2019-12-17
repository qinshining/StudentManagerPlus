using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ScoreList
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public double CSharp { get; set; }
        public double SQLServerDB { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
