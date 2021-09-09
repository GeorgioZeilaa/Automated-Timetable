using System;
using System.Collections.Generic;
using System.Text;
using AutomatedTimeTable.Model;
using AutomatedTimeTable.ModelCreation;

namespace AutomatedTimeTable.Controller
{
    class BuilderClass
    {
        public List<Group> GroupCreation(int MaxStudentsPerGroup, int MaxGroupsPerTeacher, List<Student> studentList, List<Teacher> teacherList)
        {
            GroupCreation groupCreation = new GroupCreation(MaxStudentsPerGroup, MaxGroupsPerTeacher, studentList, teacherList);
            return groupCreation.Populate();
        }
        public List<Student> StudentCreation(int numberOfStudents)
        {
            StudentCreation studentCreation = new StudentCreation(numberOfStudents);
            return studentCreation.Populate();
        }
        public List<Teacher> TeacherCreation(int numberOfTeachers)
        {
            TeacherCreation teacherCreation = new TeacherCreation(numberOfTeachers);
            return teacherCreation.Populate();
        }
        public List<Lesson> LessonCreation(int NumberOfLessonsPerGroup, List<Group> groups)
        {
            LessonCreation LessonCreation = new LessonCreation(NumberOfLessonsPerGroup, groups);
            return LessonCreation.Populate();
        }
    }
}
