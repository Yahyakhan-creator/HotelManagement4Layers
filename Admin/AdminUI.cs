using System;

namespace HotelManagement
{
    class AdminUI
    {
        AdminLogic adminLogic = new AdminLogic();
        BookingUI bookingUI = new BookingUI();

        public void Start()
        {
            if (!Login())
            {
                Console.WriteLine("Access denied");
                Console.ReadKey(true);
                return;
            }

            Menu();
        }

        bool Login()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();

                Console.WriteLine("Admin Login Attempt " + (i + 1));

                Console.Write("Enter username: ");
                string user = Console.ReadLine();

                Console.Write("Enter password: ");
                string pass = Console.ReadLine();

                if (adminLogic.Login(user, pass))
                {
                    Console.WriteLine("Login successful");
                    Console.ReadKey(true);
                    return true;
                }
                else
                {
                    Console.WriteLine("Wrong credentials");
                    Console.ReadKey(true);
                }
            }

            return false;
        }

        void Menu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("--------------ADMIN MENU---------------");
                Console.WriteLine("1. VIEW BOOKINGS");
                Console.WriteLine("2. SEARCH BOOKING");
                Console.WriteLine("3. UPDATE BOOKING");
                Console.WriteLine("4. DELETE BOOKING");
                Console.WriteLine("5. TOTAL REVENUE");
                Console.WriteLine("6. LOGOUT");

                int op = Convert.ToInt32(Console.ReadLine());

                if (op == 1) bookingUI.ViewBookings();
                else if (op == 2) bookingUI.SearchBooking();
                else if (op == 3) bookingUI.AdminUpdateBooking();
                else if (op == 4) bookingUI.AdminDeleteBooking();
                else if (op == 5) bookingUI.TotalRevenue();
                else if (op == 6) break;
            }
        }
    }
}
