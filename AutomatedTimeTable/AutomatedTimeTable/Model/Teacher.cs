using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AutomatedTimeTable
{
    class Teacher
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Subject subjects { get; set; }
        public string working_hours { get; set; }
        public Teacher() { }
        public Teacher(string first_name)
        {
            this.first_name = first_name;
        }
        public override string ToString()
        {
            return "Teacher Name: " + first_name;
        }
    }
}
