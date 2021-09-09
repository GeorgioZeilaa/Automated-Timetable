using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AutomatedTimeTable
{
    class Subject
    {
        public string name { get; set; }

        public Subject() { }

        public Subject(string name) 
        { 
            this.name = name;
        }
        public override string ToString()
        {
            return "\tSubject: " + name;
        }
    }
}
