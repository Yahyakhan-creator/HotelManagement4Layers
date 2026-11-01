using System;

namespace HotelManagement
{
    class CustomerUI
    {
        BookingUI bookingUI = new BookingUI();

        public void Menu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("CUSTOMER MENU");
                Console.WriteLine("1. BOOK ROOM");
                Console.WriteLine("2. VIEW BOOKING");
                Console.WriteLine("3. DELETE BOOKING");
                Console.WriteLine("4. UPDATE BOOKING");
                Console.WriteLine("5. MY TOTAL BILL");
                Console.WriteLine("6. BACK");

                int op = Convert.ToInt32(Console.ReadLine());

                if (op == 1) bookingUI.BookRoom();
                else if (op == 2) bookingUI.ViewMyBooking();
                else if (op == 3) bookingUI.DeleteMyBooking();
                else if (op == 4) bookingUI.UpdateMyBooking();
                else if (op == 5) bookingUI.MyTotalBill();
                else if (op == 6) break;
            }
        }
    }
}
