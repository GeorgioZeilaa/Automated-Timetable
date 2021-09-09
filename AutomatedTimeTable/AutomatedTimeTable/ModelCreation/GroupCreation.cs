using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatedTimeTable
{
    class GroupCreation
    {
        
/*         * Takes number of students per group, max groups per teacher and list of students and teachers
         * Generates groups according to teachers' and students' subject
         * When limit reached of max number of students per group then a new group is created with the same teacher
         * Once the teacher max groups limit is reached then the students will no longer be allocated to that teacher 
         * The students who are not allocated at first then will be tried to be allocated for the next teacher
         * Finally this will return a list of groups where each group contains, a teacher, a subject and list of students.
         * 
         * Input: max students per group, max groups per teacher, list of students, list of teachers.
         * Output: List of groups.*/

        private int MaxStudentsPerGroup { get; set; }
        private int MaxGroupsPerTeacher { get; set; }
        private List<Student> studentList { get; set; }
        private List<Teacher> teacherList { get; set; }
        private List<Group> groupList { get; set; }

        public GroupCreation(int MaxStudentsPerGroup, int MaxGroupsPerTeacher, List<Student> studentList, List<Teacher> teacherList)
        {
            this.MaxStudentsPerGroup = MaxStudentsPerGroup;
            this.MaxGroupsPerTeacher = MaxGroupsPerTeacher;
            this.studentList = studentList;
            this.teacherList = teacherList;
        }

        public List<Group> Populate()
        {
            List<Student> studentsListOfGroup;
            groupList = new List<Group>();
            Group groupToAdd;

            for (int i = 0; i < teacherList.Count; i++)
            {
                studentsListOfGroup = new List<Student>();
                int groupCount = 0;
                
                for (int j = 0; j < studentList.Count; j++)
                {
                    for (int k = 0; k < studentList[j].subjects.Count; k++)
                    {
                        if(teacherList[i].subjects.name == studentList[j].subjects[k].name)
                        {
                            if (!studentHasSubjectGroup(studentList[j].subjects[k], studentList[j]))
                            {
                                if (groupCount < MaxGroupsPerTeacher)
                                {
                                    studentsListOfGroup.Add(studentList[j]);

                                    if (studentsListOfGroup.Count > MaxStudentsPerGroup)
                                    {
                                        groupToAdd = new Group(studentsListOfGroup, teacherList[i], teacherList[i].subjects);
                                        groupList.Add(groupToAdd);
                                        studentsListOfGroup = new List<Student>();
                                        groupCount++;
                                    }
                                }
                            }
                        }
                    }
                }
                if (studentsListOfGroup.Count != 0)
                {
                    groupToAdd = new Group(studentsListOfGroup, teacherList[i], teacherList[i].subjects);
                    groupList.Add(groupToAdd);
                }
            }
            //checkUnallocatedStudents();
            return groupList;
        }

        public bool studentHasSubjectGroup(Subject studentSubject, Student student)
        {
            for (int i = 0; i < groupList.Count; i++)
            {
                if (groupList[i].subject.name == studentSubject.name)
                {
                    for (int j = 0; j < groupList[i].student.Count; j++)
                    {
                        if (groupList[i].student[j] == student)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void checkUnallocatedStudents()
        {
            Console.WriteLine("Students without a group allocation: ");
            for(int i = 0; i < studentList.Count; i++)
            {
                for (int j = 0; j < studentList[i].subjects.Count; j++)
                {
                    if(!studentHasSubjectGroup(studentList[i].subjects[j], studentList[i]))
                    {
                        Console.WriteLine("Student Name: " + studentList[i].first_name + " Subject: " + studentList[i].subjects[j].name);
                    }
                }
            }
        }
    }
}
