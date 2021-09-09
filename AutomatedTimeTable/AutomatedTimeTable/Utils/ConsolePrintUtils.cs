using AutomatedTimeTable.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatedTimeTable.Utils
{
    class ConsolePrintUtils
    {
        public void printStudents(List<Student> pupils)
        {
            Console.WriteLine("----------------STUDENTS----------------");
            foreach (Student pupil in pupils)
            {
                Console.WriteLine(pupil);

                for (int j = 0; j < pupil.subjects.Count; j++)
                {
                    Console.WriteLine(pupil.subjects[j]);
                }
            }
            Console.WriteLine("----------------------------------------");
        }
        public void printTeachers(List<Teacher> teachers)
        {
            Console.WriteLine("----------------TEACHERS----------------");
            foreach (Teacher teacher in teachers)
            {
                Console.WriteLine(teacher);
                Console.WriteLine(teacher.subjects);
            }
            Console.WriteLine("----------------------------------------");
        }
        public void printGroups(List<Group> groups)
        {
            Console.WriteLine("------------------GROUPS----------------");
            Console.WriteLine("------");
            Console.WriteLine("Groups");
            for (int i = 0; i < groups.Count; i++)
            {
                Console.WriteLine(groups[i].teacher);
                Console.WriteLine(groups[i].subject);

                for (int j = 0; j < groups[i].student.Count; j++)
                {
                    Console.WriteLine("\t\t" + groups[i].student[j]);
                }
            }
            Console.WriteLine("----------------------------------------");
        }
        public void printTimetable(Lesson[,,] timetable)
        {
            Console.WriteLine("-----------------LESSONS----------------");
            for (int day = 0; day < timetable.GetLength(0); day++)
            {
                if (day == 0) { Console.WriteLine("Monday"); }
                if (day == 1) { Console.WriteLine("Tuesday"); }
                if (day == 2) { Console.WriteLine("Wednesday"); }
                if (day == 3) { Console.WriteLine("Thursday"); }
                if (day == 4) { Console.WriteLine("Friday"); }

                for (int period = 0; period < timetable.GetLength(1); period++)
                {
                    if (period == 0) { Console.WriteLine("9-10"); }
                    if (period == 1) { Console.WriteLine("10-11"); }
                    if (period == 2) { Console.WriteLine("11-12"); }
                    if (period == 3) { Console.WriteLine("12-13"); }
                    if (period == 4) { Console.WriteLine("13-14"); }
                    if (period == 5) { Console.WriteLine("14-15"); }
                    if (period == 6) { Console.WriteLine("15-16"); }
                    if (period == 7) { Console.WriteLine("16-17"); }
                    if (period == 8) { Console.WriteLine("17-18"); }
                    if (period == 9) { Console.WriteLine("18-19"); }

                    for (int lesson = 0; lesson < timetable.GetLength(2); lesson++)
                    {
                        if (timetable[day, period, lesson] != null)
                        {
                            Console.WriteLine(timetable[day, period, lesson].Group);// TODO show days, periods and lessons.
                        }
                    }
                }

            }
            Console.WriteLine("----------------------------------------");
        }

    }
}
