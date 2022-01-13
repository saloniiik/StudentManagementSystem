using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem
{
    class Enroll
    {
        Info info = new Info();
        
        public string enStudentId { get; set; }
        public string enStudentName { get; set; }
        public DateTime enDOB { get; set; }
        public string enCourseID { get; set; }
        public string enCourseName { get; set; }
        public string eCourseType { get; set; }
        public string enCourseDuration { get; set; }
        public float enCoursefees { get; set; }
        public string ePlacement;
        public DateTime enrollmentDate { get; set; }
        public DiplomaType eDiplomaType;
        public Level eDegreeLevel;

        List<Course> courses = new List<Course>();
        List<Student> students = new List<Student>();
        List<Enroll> enrollments = new List<Enroll>();

        public Enroll() { }
        Enroll(Student student, Course course, DateTime enrollmentDate)
        {
            this.enStudentId = student.StudentId;
            this.enStudentName = student.StudentName;
            this.enDOB = student.DOB;
            this.enCourseID = course.CourseId;
            this.enCourseName = course.CourseName;
            this.eCourseType = course.type;
            this.enCourseDuration = course.CourseDuration;
            this.enCoursefees = course.CourseFees;
            this.enrollmentDate = enrollmentDate;
            this.eDiplomaType = course.diplomaType;
            this.eDegreeLevel = course.Degreelevel;
            this.ePlacement = course.optedPlacment;
        }

        public void introduce(Course course)
        {
            courses.Add(course);
        }

        public void register(Student student)   
        {
            students.Add(student);
        }

        public Boolean checkStudent(string id, Boolean status)
        {
            int count = 0;
            foreach (Student s in students)
            {
                if (s.StudentId.Equals(id))
                {
                    count++;
                }
            }
            if (count == 0)
            {
                status = false;
            }
            return status;
        }

        public List<Student> listOfStudents1()
        {
            return students;
        }

        public List<Course> listOfCourses()
        {
            return courses;
        }
        

        public void preEnrollment(string StudentId, string Courseid, string placement)
        {
            try
            {
                foreach (Course c in courses)
                {
                    if (c.CourseId.Equals(Courseid))
                    {
                        int count = 0;
                        foreach (Enroll e in enrollments)
                        {
                            if (e.enCourseID.Equals(Courseid))
                            {
                                count++;
                            }
                        }
                        if (count == c.availibility)
                        {
                            throw new NoSeatsAvailableException("Sorry no seats avaible");
                        }
                        if (count < c.availibility)
                        {
                            foreach (Student s in students)
                            {
                                if (s.StudentId.Equals(StudentId))
                                {
                                    if (c.type.Equals("Diploma"))
                                    {
                                        enroll(new Student(StudentId, s.StudentName, s.DOB), new Diploma(Courseid, c.CourseName, c.CourseDuration, c.CalculateFees(true), c.availibility,c.type, c.diplomaType));
                                    }
                                    if ((c.type.Equals("Degree")) & (placement.Equals("YES")))
                                    {
                                        enroll(new Student(StudentId, s.StudentName, s.DOB), new Degree(Courseid, c.CourseName, c.CourseDuration, c.CalculateFees(true), c.availibility, c.type, c.Degreelevel, "Yes"));
                                    }
                                    if ((c.type.Equals("Degree")) & (placement.Equals("NO")))
                                    {
                                        enroll(new Student(StudentId, s.StudentName, s.DOB), new Degree(Courseid, c.CourseName, c.CourseDuration, c.CalculateFees(false), c.availibility, c.type, c.Degreelevel, "No"));
                                    }
                                    
                                }
                            }
                        }
                    }
                }
            }
            catch (NoSeatsAvailableException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void enroll(Student student, Course course)
        {
            enrollments.Add(new Enroll(student, course, DateTime.Now));
            info.display("SuccessFully Enrolled...");
        }

        public List<Enroll> listOfEnrollments()
        {
            return enrollments;
        }

        public void listOfEnrollments(string input)
        {
            foreach (Enroll e in enrollments)
            {
                if (e.eCourseType.Equals(input) | (e.enCourseID.Equals(input)))
                {
                    info.display(e);
                }
            }
        }

        public Boolean checkEnrollment(string StudentId, Boolean status)
        {
            foreach (Enroll e in enrollments)
            {
                if (e.enStudentId.Equals(StudentId))
                {
                    status = false;
                }
            }
            return status;
        }
    }
}
