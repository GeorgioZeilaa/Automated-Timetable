using System;
using System.Collections.Generic;
using System.Text;
using AutomatedTimeTable.Model;

namespace AutomatedTimeTable.ModelCreation
{
    class LessonCreation
    {
        /*
         * Creates the lessons according to the groups and number of lessons per group.
         * This will keep creating lessons for each group until the number of lessons per group is reached.
         * 
         * Input: Number of lessons per group and list of groups.
         * Output: List of lessons.
         * 
         */
        private int NumberOfLessonsPerGroup { get; set; }
        private List<Group> groups { get; set; }

        public LessonCreation(int NumberOfLessonsPerGroup, List<Group> groups)
        {
            this.NumberOfLessonsPerGroup = NumberOfLessonsPerGroup;
            this.groups = groups;
        }

        public List<Lesson> Populate()
        {
            List<Lesson> Lessons = new List<Lesson>();

            for (int i = 0; i < groups.Count; i++)
            {
                for (int j = 0; j < NumberOfLessonsPerGroup; j++)
                {
                    Lesson lesson = new Lesson(groups[i]);
                    Lessons.Add(lesson);
                }
            }
            return Lessons;
        }
    }
}
