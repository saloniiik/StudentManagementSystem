using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem
{
    interface IUserInterface
    {
        void showFirstScreen();
        void showStudentScreen();
        void showAdminScreen();
        void showAllStudentsScreen();
        void showStudentRegistrationScreen();
        void introduceNewCourseScreen();
        void showAllCoursesScreen();
    }
}
