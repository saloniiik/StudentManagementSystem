using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem
{
    class Info
    {
        
        public void display(Student s)
        {
            Console.WriteLine("{0,-10}{1,-15}{2,-20}", s.StudentId, s.StudentName, s.DOB.ToShortDateString());
        }
        public void display(Course c)
        {
            if (c.type.Equals("Diploma"))
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", c.CourseId, c.CourseName, c.CalculateFees(true), c.CourseFees, c.type, c.availibility, c.diplomaType);
            }
            if (c.type.Equals("Degree"))
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", c.CourseId, c.CourseName, c.CourseDuration, c.CalculateFees(false), c.type, c.availibility, c.Degreelevel);
            }
        }
        public void display(Enroll e)
        {
            if (e.eCourseType.Equals("Diploma"))
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", e.enStudentId, e.enStudentName, e.enDOB.ToShortDateString(), e.enCourseID, e.enCourseName, e.enCourseDuration, e.enCoursefees, e.enrollmentDate.ToShortDateString(), e.eCourseType, e.eDiplomaType);
            }
            if (e.eCourseType.Equals("Degree"))
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10}", e.enStudentId, e.enStudentName, e.enDOB.ToShortDateString(), e.enCourseID, e.enCourseName, e.enCourseDuration, e.enCoursefees, e.enrollmentDate.ToShortDateString(), e.eCourseType, e.eDegreeLevel, e.ePlacement);
            }
            
        }
        public void display(string s)
        {
            Console.WriteLine(s);
        }
    }
}
