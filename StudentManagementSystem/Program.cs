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
                Console.WriteLine("Interface");
                desc.showFirstScreen();
            }
        }
    }
}
