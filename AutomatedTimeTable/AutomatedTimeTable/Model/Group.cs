using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatedTimeTable
{
    class Group
    {
        public List<Student> student { get; set; }
        public Teacher teacher { get; set; }
        public Subject subject { get; set; }

        public Group() { }
        public Group(List<Student> student, Teacher teacher, Subject subject)
        {
            this.student = student;
            this.teacher = teacher;
            this.subject = subject;
        }
        public override string ToString()
        {
            return "\nStudents: " + string.Join("",student) + "\nTeachers: " + teacher + "\nSubjects: " + subject;
        }
    }
}
