﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public string StudentIdNo { get; set; }
        public string CardNo { get; set; }
        public string StuImage { get; set; }
        public string PhoneNumber { get; set; }
        public string StudentAddress { get; set; }
        public int ClassId { get; set; }
        //扩展属性
        public string ClassName { get; set; }
        public string GenderName
        {
            get { return Gender == 1 ? "男" : "女"; }
        }
        public ScoreList ScoreList { get; set; }
        public Attendance Attendance { get; set; }
    }
}
