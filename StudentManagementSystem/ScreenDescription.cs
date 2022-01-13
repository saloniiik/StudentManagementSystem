using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem
{
    class ScreenDescription : IUserInterface
    {
        Enroll en = new Enroll();
        Info info = new Info();
        public void showFirstScreen()
        {
            Console.WriteLine("----------Welcome to Student Management System----------");
            Console.WriteLine("\nLogin as : \n\n1. Student\n2. Admin");
            
                int op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        showStudentScreen();
                        break;
                    case 2:
                        showAdminScreen();
                        break;
                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }
        }
        public void showStudentScreen()
        {
            Boolean status = true;
            do
            {
                Console.WriteLine("---------Welcome to Student Center----------");
                Console.WriteLine("\nEnter your choice:\n\n1.Register\n2.Enroll for a Course\n3.Show all Student Enrollments\n4.Show all Student Details\n" +
                    "5.Show all courses\n6.Exit");
                int ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        showStudentRegistrationScreen();
                        break;
                    case 2:
                        showCourseEnrollmentScreen();
                        break;
                    case 3:
                        showAllEnrollments();
                        break;
                    case 4:
                        studentByID();
                        break;
                    case 5:
                        showAllCoursesScreen();
                        break;
                    case 6:
                        status = false;
                        break;
                    default:
                        Console.WriteLine("Please enter correct choice");
                        break;
                }
            } while (status);
        }
        public void showAdminScreen()
        {
            Boolean status = true;
            do
            {
                Console.WriteLine("\n----------Welcome to Admin Dashboard----------\n");
                Console.WriteLine("\nEnter your choice:\n\n1.Show all Student Details\n2.Show all current Student Enrollments\n" +
                    "3.Introduce new course\n4.Show all courses\n5.Display Student Details by ID\n6.Admit a student in university\n7.Exit");
                int ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        showAllStudentsScreen();
                        break;
                    case 2:
                        showAllEnrollments();
                        break;
                    case 3:
                        introduceNewCourseScreen();
                        break;
                    case 4:
                        showAllCoursesScreen();
                        break;
                    case 5:
                        studentByID();
                        break;
                    case 6:
                        showStudentRegistrationScreen();
                        break;
                    case 7:
                        status = false;
                        break;
                    default:
                        Console.WriteLine("Please enter correct choice");
                        break;
                }
            } while (status);
        }

        
        public void showStudentRegistrationScreen()
        {
            Boolean status = true;
            Console.WriteLine("\n-----Student Admission-----\n");
            Console.WriteLine("Enter the student details to be added:\n");
            Console.WriteLine("Student ID:");
            string StudentId = Console.ReadLine();
            try
            {
            if (en.checkStudent(StudentId, status))//checks if student is registered
            {
                    throw new AlreadyRegistered("Student Already Registered!");
            }
            else
            {
                    Console.WriteLine("Student Name:");
                    string StudentName = Console.ReadLine();
                    Console.WriteLine("Student DOB:");
                    DateTime DOB = Convert.ToDateTime(Console.ReadLine());
                    en.register(new Student(StudentId, StudentName, DOB));
                    info.display("Student registered successfully...");
            }
            }
            catch (AlreadyRegistered e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void introduceNewCourseScreen()
        {
            try
            {
                Console.WriteLine("\n-----Add a new Course-----\n");
                Console.WriteLine("Enter the course details to be added:\n");
                Console.WriteLine("Course ID:");
                string CourseId = Console.ReadLine();
                Console.WriteLine("Course Name:");
                string CourseName = Console.ReadLine();
                Console.WriteLine("Course Duration:");
                string CourseDuration = Console.ReadLine();
                Console.WriteLine("Course Basic Fees:");
                float CourseFees = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter seat availibility:");
                int availibility = int.Parse(Console.ReadLine());
                Console.WriteLine("Course type :\n1.Diploma 2.Degree");
                int ch = int.Parse(Console.ReadLine());
   
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Enter diploma type:");
                        int k = 1;
                        foreach (DiplomaType i in Enum.GetValues(typeof(DiplomaType)))
                        {
                            Console.WriteLine($"{k} {i}");
                            k++;
                        }
                        int TYPE = int.Parse(Console.ReadLine());
                        switch(TYPE){
                            case 1:
                                en.introduce(new Diploma(CourseId, CourseName, CourseDuration, CourseFees, availibility, "Diploma", DiplomaType.Academic));//introduces Diploma Course
                                info.display("New course introduced...");
                                break;
                            case 2:
                                en.introduce(new Diploma(CourseId, CourseName, CourseDuration, CourseFees, availibility, "Diploma", DiplomaType.Professional));
                                info.display("New course introduced...");
                                break;
                            default:
                                Console.WriteLine("Enter valid choice!");
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter Degree level:");
                        int d = 1;
                        foreach (Level i in Enum.GetValues(typeof(Level)))
                        {
                            Console.WriteLine($"{d} {i}");
                            d++;
                        }
                        int level = int.Parse(Console.ReadLine());
                        switch (level)
                        {
                            case 1:
                                en.introduce(new Degree(CourseId, CourseName, CourseDuration, CourseFees, availibility, "Degree", Level.Bachelors, "No"));//introduces Diploma Course
                                info.display("New course introduced...");
                                break;
                            case 2:
                                en.introduce(new Degree(CourseId, CourseName, CourseDuration, CourseFees, availibility, "Degree", Level.Masters, "No"));//introduces Diploma Course
                                info.display("New course introduced...");
                                break;
                            default:
                                Console.WriteLine("Enter valid choice!");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Enter Valid Choice");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void showCourseEnrollmentScreen()
        {
            Boolean status = true;
            Console.WriteLine("Student ID:");
            string StudentId = Console.ReadLine();
            try
            {
                if (en.checkStudent(StudentId, status))//checks if student is registred
                {
                    if (en.checkEnrollment(StudentId, status))//checks if student is enrolled in any other course
                    {
                        Console.WriteLine("Enter course type: \n1.Diploma \n2.Degree");
                        int type = int.Parse(Console.ReadLine());
                        switch (type)
                        {
                            case 1:
                                int k = 1;
                                Console.WriteLine("Enter Diploma type:");
                                foreach (DiplomaType i in Enum.GetValues(typeof(DiplomaType)))
                                {
                                    Console.WriteLine($"{k} {i}");
                                    k++;
                                }
                                int DipType = int.Parse(Console.ReadLine());
                                switch (DipType)
                                {
                                    case 1:
                                        Console.WriteLine("Available Diploma Courses are:");
                                        Console.WriteLine("{0,-20}{1,-30}{2,-20}{3,-15}", "Id", "Name", "Y", "Fees");
                                        foreach (Course c in en.listOfCourses())//lists courses of type Diploma
                                        {
                                            if ((c.type.Equals("Diploma")) & (c.diplomaType.Equals(DiplomaType.Academic)))
                                            {
                                                info.display(c);
                                            }
                                        }
                                        break;
                                    case 2:
                                        Console.WriteLine("Available Diploma Courses are:");
                                        Console.WriteLine("{0,-20}{1,-30}{2,-20}{3,-15}", "Id", "Name", "Y", "Fees");
                                        foreach (Course c in en.listOfCourses())//lists courses of type Diploma
                                        {
                                            if ((c.type.Equals("Diploma")) & (c.diplomaType.Equals(DiplomaType.Professional)))
                                            {
                                                info.display(c);
                                            }
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Enter Valid Choice...");
                                        break;
                                }
                                Console.WriteLine("Enter Course ID:");
                                string DipCourseID = Console.ReadLine();
                                en.preEnrollment(StudentId, DipCourseID,"YES");
                                break;
                            case 2:
                                k = 1;
                                Console.WriteLine("Level of degree course:");
                                foreach (Level i in Enum.GetValues(typeof(Level)))
                                {
                                    Console.WriteLine($"{k} {i}");
                                    k++;
                                }
                                int DegreeLevel = int.Parse(Console.ReadLine());
                                switch (DegreeLevel)
                                {
                                    case 1:
                                        Console.WriteLine("Available Courses are:");
                                        Console.WriteLine("{0,-20}{1,-30}{2,-20}{3,-15}", "Id", "Name", "Y", "Fees");
                                        foreach (Course c in en.listOfCourses())//lists courses of type Degree
                                        {
                                            if ((c.type.Equals("Degree")) & (c.Degreelevel.Equals(Level.Bachelors)))
                                            {
                                                info.display(c);
                                            }
                                        }
                                        break;
                                    case 2:
                                        Console.WriteLine("Available Courses are:");
                                        Console.WriteLine("{0,-20}{1,-30}{2,-20}{3,-15}", "Id", "Name", "Y", "Fees");
                                        foreach (Course c in en.listOfCourses())//lists courses of type Degree
                                        {
                                            if ((c.type.Equals("Degree")) & (c.Degreelevel.Equals(Level.Masters)))
                                            {
                                                info.display(c);
                                            }
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Enter valid choice");
                                        break;
                                }
                                Console.WriteLine("Enter Course ID:");
                                string DEgCourseID = Console.ReadLine();
                                Console.WriteLine("Do you want to participate for placements:(type yes/no)");
                                string placements = Console.ReadLine();
                                if (placements.ToUpper().Equals("YES"))
                                {
                                    en.preEnrollment(StudentId, DEgCourseID,"YES");
                                }
                                else
                                {
                                    en.preEnrollment(StudentId, DEgCourseID,"NO");
                                }
                                break;
                            default:
                                Console.WriteLine("Enter Valid Choice");
                                break;
                        }
                    }
                    else
                    {
                        throw new AlreadyEnrolled("Only one enrrollment is allowed per student!");
                    }
                }
                else
                {
                    throw new NotRegistered("Only Registered students can enroll. Register first.");
                }
            }
            catch (AlreadyEnrolled e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NotRegistered e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void showAllStudentsScreen()
        {
            Console.WriteLine("{0,-10}{1,-15}{2,-20}", "StudentID", "StudentName", "DateOfBirth");
            foreach(var item in en.listOfStudents1())
            {
                info.display(item);
            } 
        }

        public void studentByID()
        {
            Console.WriteLine("Enter ID:");
            string id = Console.ReadLine();
            try
            {
                if (en.checkStudent(id, true))//checks if student is registered
                {
                    Console.WriteLine("{0,-10}{1,-15}{2,-20}", "StudentID", "StudentName", "DateOfBirth");
                    foreach (var item in en.listOfStudents1())
                    {
                        if (item.StudentId.Equals(id))
                        {
                            info.display(item);
                        }
                    }
                }
                else
                {
                    throw new NotRegistered("Student not present.");
                }
            }
            catch (NotRegistered e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void showAllCoursesScreen()
        {
            //Console.WriteLine("{0,-20}{1,-30}{2,-20}{3,-15}{4,-20}{5,-20}", "Id", "Name", "Y", "Fees", "type", "Seats");
            foreach (Course c in en.listOfCourses())
            {
                info.display(c);   
            }
        }

        public void showAllEnrollments()
        {
            Console.WriteLine("Enter Choice:\n1.By course type\n2.By course ID\n3.All enrollments");
            int a = int.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Console.WriteLine("Enter Type:(Degree/Diploma)");
                    string input = Console.ReadLine();
                    en.listOfEnrollments(input);//filters enrollments by type
                    break;
                case 2:
                    Console.WriteLine("Enter Course id:");
                    input = Console.ReadLine();
                    en.listOfEnrollments(input);//filters enrollments by course id
                    break;
                case 3:
                    foreach (Enroll e in en.listOfEnrollments())//lists all enrollments
                    {
                        info.display(e);
                    }
                    break;
                default:
                    Console.WriteLine("Enter Valid Choice");
                    break;
            }
        }
    }
}
