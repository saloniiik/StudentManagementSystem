using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem
{
    class Student
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime DOB { get; set; }

        public Student() { }
        public Student(string StudentId, string StudentName, DateTime DOB)
        {
            this.StudentId = StudentId;
            this.StudentName = StudentName;
            this.DOB = DOB;
        }
    }
}
