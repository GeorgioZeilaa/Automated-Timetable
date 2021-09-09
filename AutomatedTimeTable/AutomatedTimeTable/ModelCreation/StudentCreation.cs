using System;
using System.Collections.Generic;
using System.Text;
using AutomatedTimeTable.Controller;

namespace AutomatedTimeTable
{
    class StudentCreation
    {
        /*
         * Takes a number of students to create
         * Assigns a random number of subjects to them that are unique.
         * 
         * Input: Number of students to create.
         * Output: List of students.
         */

        private int numberOfStudents { get; set; }
        public StudentCreation(int numberOfStudents)
        {
            this.numberOfStudents = numberOfStudents;
        }
        public List<Student> Populate()
        {
            List<Student> Students = new List<Student>();

            SubjectPopulate Subject = new SubjectPopulate();

            for (int i = 0; i < numberOfStudents; i++)
            {
                Student student = new Student("#" + i);
                student.subjects = Subject.ReturnRandomSubjects();// To receive a random list of subjects for a specific student
                Students.Add(student);
            }
            return Students;
        }
    }
}
