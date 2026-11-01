using System;
using System.Collections.Generic;
using System.IO;

namespace HotelManagement
{
    class BookingDataAccess
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "bookings.txt");

        public List<Booking> LoadAll()
        {
            if (!File.Exists(filePath))
            {
                CreateSampleFile();
            }

            List<Booking> list = new List<Booking>();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (line.Trim() == "")
                    continue;

                string[] parts = line.Split('|');

                int room = Convert.ToInt32(parts[0]);
                string name = parts[1];
                int days = Convert.ToInt32(parts[2]);
                float rent = Convert.ToSingle(parts[3]);
                bool booked = Convert.ToBoolean(parts[4]);

                Customer c = new Customer(name);
                Booking b = new Booking(room, c, days, rent);
                b.Booked = booked;

                list.Add(b);
            }

            return list;
        }

        public void SaveAll(List<Booking> list)
        {
            List<string> lines = new List<string>();

            foreach (Booking b in list)
            {
                string line = b.RoomNo + "|" + b.Customer.Name + "|" + b.Days + "|" + b.Rent + "|" + b.Booked;
                lines.Add(line);
            }

            File.WriteAllLines(filePath, lines);
        }

        void CreateSampleFile()
        {
            int[] rooms = { 101, 102, 103 };
            string[] names = { "Ali", "Taha", "Usman" };
            int[] days = { 2, 3, 1 };
            float[] rents = { 2000, 2500, 1800 };

            List<Booking> list = new List<Booking>();

            for (int i = 0; i < rooms.Length; i++)
            {
                Customer c = new Customer(names[i]);
                Booking b = new Booking(rooms[i], c, days[i], rents[i]);
                list.Add(b);
            }

            SaveAll(list);
        }
    }
}
