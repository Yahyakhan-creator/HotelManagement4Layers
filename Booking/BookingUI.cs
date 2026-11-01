using System;
using System.Collections.Generic;

namespace HotelManagement
{
    class BookingUI
    {
        BookingLogic bookingLogic = new BookingLogic();

        public void ViewBookings()
        {
            bool found = false;

            Console.WriteLine("Room   Name   Days   Rent");

            foreach (Booking b in bookingLogic.GetAll())
            {
                if (b.Booked)
                {
                    Console.WriteLine(b);
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No bookings found");

            Console.ReadKey(true);
        }

        public void SearchBooking()
        {
            Console.Write("Enter room number to search: ");
            int r = Convert.ToInt32(Console.ReadLine());

            Booking b = bookingLogic.FindByRoom(r);

            if (b != null)
                Console.WriteLine(b);
            else
                Console.WriteLine("Booking not found");

            Console.ReadKey(true);
        }

        public void AdminUpdateBooking()
        {
            Console.Write("Enter room number to update: ");
            int r = Convert.ToInt32(Console.ReadLine());

            Booking b = bookingLogic.FindBookedByRoom(r);

            if (b == null)
            {
                Console.WriteLine("Booking not found");
            }
            else
            {
                Console.Write("Enter new name: ");
                string newName = Console.ReadLine();

                Console.Write("Enter new days: ");
                int newDays = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter new rent: ");
                float newRent = Convert.ToSingle(Console.ReadLine());

                bookingLogic.AdminUpdate(r, newName, newDays, newRent);
                Console.WriteLine("Booking updated");
            }

            Console.ReadKey(true);
        }

        public void AdminDeleteBooking()
        {
            Console.Write("Enter room number to delete: ");
            int r = Convert.ToInt32(Console.ReadLine());

            bool deleted = bookingLogic.DeleteByRoom(r);

            if (deleted)
                Console.WriteLine("Booking deleted");
            else
                Console.WriteLine("Booking not found");

            Console.ReadKey(true);
        }

        public void TotalRevenue()
        {
            float total = bookingLogic.GetTotalRevenue();

            Console.WriteLine("Total revenue is: " + total);

            Console.ReadKey(true);
        }

        public void BookRoom()
        {
            if (bookingLogic.IsFull())
            {
                Console.WriteLine("Hotel is full. Cannot book more rooms");
                Console.ReadKey(true);
                return;
            }

            Console.Write("Enter room number: ");
            int tempRoom = Convert.ToInt32(Console.ReadLine());

            if (bookingLogic.IsRoomBooked(tempRoom))
            {
                Console.WriteLine("Room already booked");
                Console.ReadKey(true);
                return;
            }

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter days: ");
            int days = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter rent: ");
            float rent = Convert.ToSingle(Console.ReadLine());

            Booking b = bookingLogic.Add(tempRoom, name, days, rent);

            Console.WriteLine("--- Booking Receipt ---");
            Console.WriteLine("Room: " + b.RoomNo);
            Console.WriteLine("Name: " + b.Customer.Name);
            Console.WriteLine("Days: " + b.Days);
            Console.WriteLine("Rent/day: " + b.Rent);
            Console.WriteLine("Total: " + b.Total);

            Console.ReadKey(true);
        }

        public void ViewMyBooking()
        {
            Console.Write("Enter your name: ");
            string n = Console.ReadLine();

            List<Booking> myBookings = bookingLogic.GetByName(n);

            if (myBookings.Count == 0)
                Console.WriteLine("No booking found");

            foreach (Booking b in myBookings)
                Console.WriteLine(b.RoomNo + " " + b.Days + " " + b.Rent);

            Console.ReadKey(true);
        }

        public void DeleteMyBooking()
        {
            Console.Write("Enter room number: ");
            int r = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your name: ");
            string n = Console.ReadLine();

            bool deleted = bookingLogic.DeleteByRoomAndName(r, n);

            if (deleted)
                Console.WriteLine("Booking deleted");
            else
                Console.WriteLine("Booking not found or name does not match");

            Console.ReadKey(true);
        }

        public void UpdateMyBooking()
        {
            Console.Write("Enter your current room number: ");
            int r = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your name: ");
            string n = Console.ReadLine();

            Booking b = bookingLogic.FindByRoomAndName(r, n);

            if (b == null)
            {
                Console.WriteLine("Booking not found or name does not match");
                Console.ReadKey(true);
                return;
            }

            Console.Write("Enter new room number: ");
            int newRoom = Convert.ToInt32(Console.ReadLine());

            if (!bookingLogic.CanMoveToRoom(r, newRoom))
            {
                Console.WriteLine("That room is already booked");
                Console.ReadKey(true);
                return;
            }

            Console.Write("Enter new number of days: ");
            int newDays = Convert.ToInt32(Console.ReadLine());

            Booking updated = bookingLogic.UpdateRoomAndDays(r, n, newRoom, newDays);

            Console.WriteLine("--- Booking Updated ---");
            Console.WriteLine("Room: " + updated.RoomNo);
            Console.WriteLine("Name: " + updated.Customer.Name);
            Console.WriteLine("Days: " + updated.Days);
            Console.WriteLine("Rent/day: " + updated.Rent);
            Console.WriteLine("Total: " + updated.Total);

            Console.ReadKey(true);
        }

        public void MyTotalBill()
        {
            Console.Write("Enter your name: ");
            string n = Console.ReadLine();

            List<Booking> myBookings = bookingLogic.GetBookedByName(n);

            if (myBookings.Count == 0)
                Console.WriteLine("No booking found");
            else
                Console.WriteLine("Your total bill is: " + bookingLogic.GetBill(n));

            Console.ReadKey(true);
        }
    }
}
