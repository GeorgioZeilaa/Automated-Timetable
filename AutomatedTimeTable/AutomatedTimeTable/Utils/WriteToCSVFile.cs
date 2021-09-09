using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace AutomatedTimeTable.Utils
{
    class WriteToCSVFile
    {
        private static ReaderWriterLockSlim lock_ = new ReaderWriterLockSlim();

        public void addRecord(string algorithmType, int totalHardConstraintViolations, int totalNumberOfLessons, int totalNumberOfStudents, int totalNumberOfTeachers,  TimeSpan timeTaken)
        {
            lock_.EnterWriteLock();
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\kasper\Google Drive\UNI\1st year Masters\Msc Project\Graphs\graph.csv", true))
                {
                    file.WriteLine(algorithmType + "," + totalHardConstraintViolations + "," + totalNumberOfLessons + "," + totalNumberOfStudents + "," + totalNumberOfTeachers + "," + timeTaken);
                };
                Console.WriteLine("Successfully Wrote to CSV File!");
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Failed writing to the CSV file, error: ", ex);
            }
            finally
            {
                lock_.ExitWriteLock();
            }
        }
    }
}
