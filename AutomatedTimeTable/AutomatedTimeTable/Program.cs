using System;
using System.Collections.Generic;
using AutomatedTimeTable.Controller;
using AutomatedTimeTable.Model;
using AutomatedTimeTable.Utils;
using System.Threading;

namespace AutomatedTimeTable
{
    class Program
    {
        static int Days = 0;
        static int PeriodsPerDay = 0;
        static int MaxNumberOfLessonInTimeslot = 0;
        static int NumberOfStudents = 0;
        static List<Lesson> lessons;

        private static void testPopulateData()
        {
            int NumberOfStudents = 100;
            int NumberOfTeachers = 10;
            int MaxStudentsPerGroup = 10;
            int MaxGroupsPerTeacher = 3;

            BuilderClass builder = new BuilderClass();
            List<Student> students = builder.StudentCreation(NumberOfStudents);
            List<Teacher> teachers = builder.TeacherCreation(NumberOfTeachers);
            List<Group> groups = builder.GroupCreation(MaxStudentsPerGroup, MaxGroupsPerTeacher, students, teachers);

            ConsolePrintUtils consolePrintUtils = new ConsolePrintUtils();
            consolePrintUtils.printStudents(students);
            consolePrintUtils.printTeachers(teachers);
            consolePrintUtils.printGroups(groups);
        }

        private static List<Lesson> createData(int MaxGroupsPerTeacher, int MaxStudentsPerGroup, int NumberOfLessonsPerGroup, int NumberOfTeachers, int NumberOfStudent)
        {
            Days = 5;
            PeriodsPerDay = 10;
            MaxNumberOfLessonInTimeslot = 1000;
            NumberOfStudents = NumberOfStudent;

            BuilderClass builder = new BuilderClass();
            List<Student> students = builder.StudentCreation(NumberOfStudents);
            List<Teacher> teachers = builder.TeacherCreation(NumberOfTeachers);
            List<Group> groups = builder.GroupCreation(MaxStudentsPerGroup, MaxGroupsPerTeacher, students, teachers);

            Console.WriteLine("Group Count: " + groups.Count);

            //ConsolePrintUtils consolePrintUtils = new ConsolePrintUtils();
            //consolePrintUtils.printStudents(students);
            //consolePrintUtils.printTeachers(teachers);
            //consolePrintUtils.printGroups(groups);

            return builder.LessonCreation(NumberOfLessonsPerGroup, groups);
        }
        private static Lesson[,,] runBruteForce()
        {
            NaiveAlgorithm algorithm = new NaiveAlgorithm();
            algorithm.Days = Days;
            algorithm.PeriodsPerDay = Days;
            algorithm.MaxNumberOfLessonInTimeslot = MaxNumberOfLessonInTimeslot;
            algorithm.NumberOfStudents = NumberOfStudents;

            algorithm.Lessons = lessons;

            // To populate timetable
            return algorithm.execute();
        }
        private static Lesson[,,] runRandomPlacement()
        {
            RandomPlacementAlgorithm algorithm = new RandomPlacementAlgorithm();
            algorithm.Days = Days;
            algorithm.PeriodsPerDay = PeriodsPerDay;
            algorithm.MaxNumberOfLessonInTimeslot = MaxNumberOfLessonInTimeslot;
            algorithm.NumberOfStudents = NumberOfStudents;

            algorithm.Lessons = lessons;

            // To populate timetable
            return algorithm.execute();
        }
        private static Lesson[,,] runHillClimbing()
        {
            HillClimbingAlgorithm algorithm = new HillClimbingAlgorithm();
            algorithm.Days = Days;
            algorithm.PeriodsPerDay = PeriodsPerDay;
            algorithm.MaxNumberOfLessonInTimeslot = MaxNumberOfLessonInTimeslot;
            algorithm.NumberOfStudents = NumberOfStudents;
            
            algorithm.Lessons = lessons;

            // To populate timetable
            return algorithm.execute();
        }
        private static Lesson[,,] runSimulatedAnnealing()
        {
            SimulatedAnnealingAlgorithm algorithm = new SimulatedAnnealingAlgorithm();
            algorithm.Days = Days;
            algorithm.PeriodsPerDay = PeriodsPerDay;
            algorithm.MaxNumberOfLessonInTimeslot = MaxNumberOfLessonInTimeslot;
            algorithm.NumberOfStudents = NumberOfStudents;
            algorithm.Percentage = 0.1;

            algorithm.Lessons = lessons;

            // To populate timetable
            return algorithm.execute();
        }

        private static void runAndReport(int option, int MaxGroupsPerTeacher, int MaxStudentsPerGroup, int NumberOfLessonsPerGroup, int NumberOfTeachers, int NumberOfStudent)
        {
            WriteToCSVFile file = new WriteToCSVFile();
            Lesson[,,] timetable = null;
            lessons = createData(MaxGroupsPerTeacher, MaxStudentsPerGroup, NumberOfLessonsPerGroup, NumberOfTeachers, NumberOfStudent);

            int lessonsCount = lessons.Count;
            string algorithmName = "";

            DateTime before = DateTime.Now;
            if (option == 1)
            {
                algorithmName = "Random Algorithm";
                timetable = runRandomPlacement();
            }
            if(option == 2)
            {
                algorithmName = "Naive Algorithm";
                timetable = runBruteForce();
            }
            if(option == 3)
            {
                algorithmName = "HillClimbing Algorithm";
                timetable = runHillClimbing();
            }
            if (option == 4)
            {
                algorithmName = "Simulated Annealing Algorithm";
                timetable = runSimulatedAnnealing();
            }
            DateTime after = DateTime.Now;

            int totalHardConstraintViolations = TimetableUtils.printReport(timetable);
            timetable = null;
            lessons = createData(MaxGroupsPerTeacher, MaxStudentsPerGroup, NumberOfLessonsPerGroup, NumberOfTeachers, NumberOfStudent);
            TimeSpan timeTaken = after - before;

            Console.WriteLine("Total time taken: " + (after - before));
            file.addRecord(algorithmName, totalHardConstraintViolations, lessonsCount, NumberOfStudents, NumberOfTeachers, timeTaken);
        }
        static void Main()
        {
            // runAndReport parameter options:
            //      1 = Random Algorithm
            //      2 = Naive Algorithm
            //      3 = HillClimbing Algorithm
            //      4 = Simulated Annealing Algorithm

            /*Thread[] threads = new Thread[100];

            for (int i = 0; i < 100; i++)
            {
                threads[i] = new Thread(() => runAndReport(3));
            }

            foreach (Thread t in threads)
            {
                t.Start();
            }*/

            // GENERATE FOR RANDOM ALGORITHM
            int numberStudent = 0;
            int numberTeacher = 0;
            for (int i = 0; i < 10000; i++)
            {
                if (i % 1000 == 0)
                {
                    numberTeacher = 5 + numberTeacher;
                    numberStudent = 0;
                }

                if (i % 100 == 0)
                {
                    numberStudent = 10 + numberStudent;
                }

                runAndReport(2, 6, 40, 3, numberTeacher, numberStudent);
                Console.WriteLine("Current loop #" + i);
            }

            // GENERATE DATA
            /*lessons = createData(3, 60, 8, 50, 500);
            Console.WriteLine("Number of lessons: " + lessons.Count);*/

            // ALGORITHMS
            /*            int numberStudent = 0;
                        int numberTeacher = 0;
                        for (int i = 0; i < 1000; i++)
                        {
                            numberStudent = 5 + numberStudent;

                            if (i % 100 == 0)
                            {
                                numberTeacher = 10 + numberTeacher;
                            }

                            runAndReport(4, 6, 40, 3, numberTeacher, numberStudent);
                            Console.WriteLine("Current loop #" + i);
                        }*/
        }
    }
}