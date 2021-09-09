using System;
using System.Collections.Generic;
using System.Text;
using AutomatedTimeTable.Controller;
using AutomatedTimeTable.Model;
using AutomatedTimeTable.Utils;

namespace AutomatedTimeTable
{
    /**
     * Takes Lessons and randomly assigns them to timeslots without any prior checks
     * This allows all lessons to be placed onto the timetable without any of them being ignored.
     */
    class RandomPlacementAlgorithm
    {
        public int Days { get; set; }
        public int PeriodsPerDay { get; set; }
        public int MaxNumberOfLessonInTimeslot { get; set; }
        public int NumberOfStudents { get; set; }

        public List<Lesson> Lessons { get; set; }

        public Lesson[,,] timetable;

        public Lesson[,,] execute()
        {            
            timetable = new Lesson[Days, PeriodsPerDay, MaxNumberOfLessonInTimeslot];
            Random rd = new Random();

            for(int i = 0; i < Lessons.Count; i++)
            {
                int rnd_Day = rd.Next(0, Days - 1);
                int rnd_Period = rd.Next(0, PeriodsPerDay - 1);

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
