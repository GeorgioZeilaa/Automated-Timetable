using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatedTimeTable.Controller
{
    class SubjectPopulate
    {
        /*
         * List of subjects gets created with randomness involved.
         * 
         * Input: None.
         * Output: random list of subjects.
         */
        public List<Subject> listOfSubjects()
        {
            List<Subject> subjects = new List<Subject>();
            subjects.Add(new Subject("Mathematics"));
            subjects.Add(new Subject("Physics"));
            subjects.Add(new Subject("History"));
            subjects.Add(new Subject("Geography"));
            subjects.Add(new Subject("Biology"));
            subjects.Add(new Subject("French"));
            subjects.Add(new Subject("English"));

            return subjects;
        }

        public List<Subject> ReturnRandomSubjects()
        {
            Random random = new Random();
            List<Subject> possibleSubjectChoices = listOfSubjects();

            List<Subject> subjects = new List<Subject>();
            Random rnd = new Random();
            int randomSubjectValue = rnd.Next(1, 5);
            for (int j = 0; j < randomSubjectValue; j++)
            {
                int randomIndex = random.Next(possibleSubjectChoices.Count);
                subjects.Add(possibleSubjectChoices[randomIndex]);
                possibleSubjectChoices.RemoveAt(randomIndex);// To remove chosen subject from list to not get same one again
            }
            return subjects;
        }
    }
}
