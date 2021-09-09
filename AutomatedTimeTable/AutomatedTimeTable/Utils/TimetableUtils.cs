using AutomatedTimeTable.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatedTimeTable.Controller
{
    class TimetableUtils
    {
        public static int printReport(Lesson[,,] timetable)
        {
            int teacherHardConstraintViolations = getTeacherHardConstraintViolations(timetable);
            int studentHardConstraintViolations = getStudentHardConstraintViolations(timetable);
            int totalScore = teacherHardConstraintViolations + studentHardConstraintViolations;

            Console.WriteLine("Hard Contraint Violations:");
            Console.WriteLine("Teachers: " + teacherHardConstraintViolations);
            Console.WriteLine("Students: " + studentHardConstraintViolations);
            Console.WriteLine("Total Violations: " + totalScore);
            return teacherHardConstraintViolations + studentHardConstraintViolations;
        }
        public static int getTeacherHardConstraintViolations(Lesson[,,] timetable)
        {
            int teacherHardConstraintViolation = 0;

            for (int day = 0; day < timetable.GetLength(0); day++)
            {
                for (int period = 0; period < timetable.GetLength(1); period++)
                {
                    for (int i = 0; i < timetable.GetLength(2); i++)
                    {
                        Lesson lessonOne = timetable[day, period, i];

                        if (lessonOne != null)
                        {
                            for (int j = i + 1; j < timetable.GetLength(2); j++)
                            {
                                Lesson lessonTwo = timetable[day, period, j];

                                if (lessonTwo != null)
                                {
                                    if (lessonOne.Group.teacher == lessonTwo.Group.teacher)
                                    {
                                        teacherHardConstraintViolation++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return teacherHardConstraintViolation;
        }
        public static int getStudentHardConstraintViolations(Lesson[,,] timetable)
        {
            int studentHardConstraintViolation = 0;

            for (int day = 0; day < timetable.GetLength(0); day++)
            {
                for (int period = 0; period < timetable.GetLength(1); period++)
                {
                    for (int i = 0; i < timetable.GetLength(2); i++)
                    {
                        Lesson lessonOne = timetable[day, period, i];

                        if (lessonOne != null)
                        {
                            for (int j = i + 1; j < timetable.GetLength(2); j++)
                            {
                                Lesson lessonTwo = timetable[day, period, j];

                                if (lessonTwo != null)
                                {
                                    if (lessonOne.Group.student == lessonTwo.Group.student)
                                    {
                                        studentHardConstraintViolation++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return studentHardConstraintViolation;
        }
    }
}
