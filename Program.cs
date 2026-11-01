using System;

namespace HotelManagement
{
    class Program
    {
        static void Main()
        {
            AdminUI adminUI = new AdminUI();
            CustomerUI customerUI = new CustomerUI();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("HOTEL MANAGEMENT SYSTEM");
                Console.WriteLine("1. ADMIN");
                Console.WriteLine("2. CUSTOMER");
                Console.WriteLine("3. EXIT");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1) adminUI.Start();
                else if (choice == 2) customerUI.Menu();
                else if (choice == 3) break;
            }
        }
    }
}
