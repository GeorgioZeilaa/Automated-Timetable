using System;
using System.Collections.Generic;
using System.Text;
using AutomatedTimeTable.Controller;
using AutomatedTimeTable.Model;
using AutomatedTimeTable.Utils;

namespace AutomatedTimeTable
{
    /**
     * For each lesson the algorithm randomly picks a timetable slot to place the lesson into.
     * If the timeslot already contains a lesson that shares a teacher or a student from that lesson,
     * another random timeslot is tried. If it cannot place that lesson after 1000 attempts, it will fail.
     * Placements are done until there all the lessons are scheduled.
     * 
     * Algorithm
     * Inputs: List of Lessons
     * Outputs: A timetable with no violations. Will fail to solve if values there are too many groups.
     */

    class NaiveAlgorithm
    {
        int MAX_PLACEMENT_ATTEMPTS = 1000;
        public int Days { get; set; }
        public int PeriodsPerDay { get; set; }
        public int MaxNumberOfLessonInTimeslot { get; set; }
        public int NumberOfStudents { get; set; }

        public List<Lesson> Lessons { get; set; }

        public Lesson[,,] timetable;
        public NaiveAlgorithm() { }

        public bool canPlaceLesson(int day, int period, Lesson lesson)
        {
            var groupToSchedule = lesson.Group;

            for (int j = 0; j < MaxNumberOfLessonInTimeslot; j++)
            {
                if (timetable[day, period, j] == null) 
                { 
                    return true; // No duplicates found or no lessons exist in the timeslot
                }

                Group scheduledGroup = timetable[day, period, j].Group;

                if (scheduledGroup.teacher == groupToSchedule.teacher)
                {
                    return false;
                }

                for(int k = 0; k < scheduledGroup.student.Count; k++)
                {
                    for (int z = 0; z < groupToSchedule.student.Count; z++)
                    {
                        if (scheduledGroup.student[k] == groupToSchedule.student[z])
                        {
                            return false;
                        } 
                    }
                }
            }
            
            return false;
        }
        public Lesson[,,] execute()
        {            
            timetable = new Lesson[Days, PeriodsPerDay, MaxNumberOfLessonInTimeslot];
            Random rd = new Random();

            for (int i = 0; i < Lessons.Count; i++)
            {
                int rnd_Day = rd.Next(0, Days - 1);
                int rnd_Period = rd.Next(0, PeriodsPerDay - 1);
                int attemptsToPlaceLesson = 0;

                while(!canPlaceLesson(rnd_Day, rnd_Period, Lessons[i]))
                {
                    attemptsToPlaceLesson++;

                    if(attemptsToPlaceLesson == MAX_PLACEMENT_ATTEMPTS)
                    {
                        Console.WriteLine("Unable to place some lessons");
                        return timetable;
                    }

                    rnd_Day = rd.Next(0, Days - 1);
                    rnd_Period = rd.Next(0, PeriodsPerDay - 1);
                }
                addLessonToTimetable(rnd_Day, rnd_Period, Lessons[i]);
            }
            return timetable;
        }
        public void addLessonToTimetable(int day, int period, Lesson lesson)
        {
            for (int j = 0; j < MaxNumberOfLessonInTimeslot; j++)
            {
                if (timetable[day, period, j] == null)
                {
                    timetable[day, period, j] = lesson;
                    break;
                }
            }
        }
    }
}
