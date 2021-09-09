using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatedTimeTable.Model
{
    class Lesson
    {
        public Group Group { get; set; }

        public Lesson() { }
        public Lesson(Group Group)
        {
            this.Group = Group;
        }

        public override string ToString()
        {
            return "Lesson" + Group;
        }
    }
}
