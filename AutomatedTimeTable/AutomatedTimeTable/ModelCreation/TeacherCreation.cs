using System;
using System.Collections.Generic;
using System.Text;
using AutomatedTimeTable.Controller;

namespace AutomatedTimeTable
{
    class TeacherCreation
    {
        /*
         * Creates teachers according to the number of teachers given.
         * 
         * Input: Number of teachers to create.
         * Output: List of teachers.
         */
        public int numberOfTeachers { get; set; }
        
        public TeacherCreation(int numberOfTeachers)
        {
            this.numberOfTeachers = numberOfTeachers;
        }
        public List<Teacher> Populate()
        {
            SubjectPopulate subjects = new SubjectPopulate();
            List<Subject> randomSubjects = subjects.listOfSubjects();// To receive list of available subjects
            List<Teacher> teachers = new List<Teacher>();
            Random rnd = new Random();

            for (int i = 0; i < numberOfTeachers; i++)
            {
                Teacher teacher = new Teacher("#" + i)
                {
                    subjects = randomSubjects[rnd.Next(0,randomSubjects.Count)]
                };

                teachers.Add(teacher);
            }
            return teachers;
        }
    }
}
