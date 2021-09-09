
using System;
using System.Collections.Generic;
using System.Text;
using AutomatedTimeTable.Controller;
using AutomatedTimeTable.Model;
using AutomatedTimeTable.Utils;

namespace AutomatedTimeTable
{
    /**
     * To produce a timetable by taking the lessons and analysing the number of violationns for each lesson
     * then placing the lesson where there are the least amount of violations.
     * 
     * Inputs: Lessons
     * Outputs: Scheduled timetable with lessons and least amount of hard contraint violations.
     */

    class SimulatedAnnealingAlgorithm
    {
        public int Days { get; set; }
        public int PeriodsPerDay { get; set; }
        public int MaxNumberOfLessonInTimeslot { get; set; }
        public int NumberOfStudents { get; set; }
        public double Percentage { get; set; }

        private int bestScoreSoFar { get; set; }
        private int bestDaySoFar { get; set; }
        private int bestPeriodSoFar { get; set; }
        private int oldScore { get; set; }
        private Lesson bestLessonSoFar { get; set; }

        public List<Lesson> Lessons { get; set; }

        public Lesson[,,] timetable;

        public Lesson[,,] execute()
        {
            timetable = new Lesson[Days, PeriodsPerDay, MaxNumberOfLessonInTimeslot];
            recurse(Lessons);

            return timetable;
        }

        private void recurse(List<Lesson> lessonToSchedule)
        {
            if (lessonToSchedule.Count == 0)
            {
                return;
            }

            int scoreTemp = TimetableUtils.getStudentHardConstraintViolations(timetable) + TimetableUtils.getTeacherHardConstraintViolations(timetable);
            //Console.WriteLine("Lessons.Count=" + Lessons.Count + " " + scoreTemp);

            oldScore = scoreTemp;

            double temperature = Percentage;
            Random rd = new Random();

            bestLessonSoFar = null;
            bestDaySoFar = -1;
            bestPeriodSoFar = -1;

            if (rd.NextDouble() < temperature) 
            {
                bestDaySoFar = rd.Next(0, Days - 1);
                bestPeriodSoFar = rd.Next(0, PeriodsPerDay - 1);
                bestLessonSoFar = Lessons[rd.Next(0, Lessons.Count)];
            } 
            else 
            {
                bestScoreSoFar = int.MaxValue;
                findBestScoreAndLesson(lessonToSchedule);
            }

            addLessonToTimetable(bestDaySoFar, bestPeriodSoFar, bestLessonSoFar);
            lessonToSchedule.Remove(bestLessonSoFar);

            recurse(lessonToSchedule);
        }

        void findBestScoreAndLesson(List<Lesson> lessonToSchedule)
        {
            for (int i = 0; i < lessonToSchedule.Count; i++)
            {
                for (int day = 0; day < Days; day++)
                {
                    for (int period = 0; period < PeriodsPerDay; period++)
                    {
                        Lesson lesson = lessonToSchedule[i];
                        int index = addLessonToTimetable(day, period, lesson);
                        int score = TimetableUtils.getStudentHardConstraintViolations(timetable) + TimetableUtils.getTeacherHardConstraintViolations(timetable);

                        if (score < bestScoreSoFar)
                        {
                            bestScoreSoFar = score;
                            bestDaySoFar = day;
                            bestPeriodSoFar = period;
                            bestLessonSoFar = lesson;
                        }

                        removeLessonFromTimetable(day, period, lesson, index);

                        if (score == oldScore)
                        {
                            i = lessonToSchedule.Count;
                            day = Days;
                            break;
                        }
                    }
                }
            }
        }

        private int addLessonToTimetable(int day, int period, Lesson lesson)
        {
            for (int j = 0; j < MaxNumberOfLessonInTimeslot; j++)
            {
                if (timetable[day, period, j] == null)
                {
                    timetable[day, period, j] = lesson;
                    return j;
                }
            }
            return -1;
        }

        private void removeLessonFromTimetable(int day, int period, Lesson lesson, int timetable_lesson_index)
        {
            timetable[day, period, timetable_lesson_index] = null;
        }
    }
}
