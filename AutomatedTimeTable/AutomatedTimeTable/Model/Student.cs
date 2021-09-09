using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace AutomatedTimeTable
{
    class Student
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string dob { get; set; }
        public string email { get; set; }
        public List<Subject> subjects { get; set; }
        public int year { get; set; }
        public Student() { }

        public Student(string first_name)
        {
            this.first_name = first_name;
        }
        public override string ToString()
        {
            return "Student Name: " + first_name;
        }
    }
}
