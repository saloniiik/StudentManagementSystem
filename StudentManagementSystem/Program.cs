using System;

namespace StudentManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserInterface desc = new ScreenDescription();
            while (true)
            {
                desc.showFirstScreen();
            }
        }
    }
}
