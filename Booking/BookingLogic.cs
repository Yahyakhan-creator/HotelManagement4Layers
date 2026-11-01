using System.Collections.Generic;

namespace HotelManagement
{
    class BookingLogic
    {
        BookingDataAccess dataAccess = new BookingDataAccess();

        int maxBookings = 100;

        public List<Booking> GetAll()
        {
            return dataAccess.LoadAll();
        }

        public bool IsFull()
        {
            List<Booking> list = dataAccess.LoadAll();
            return list.Count >= maxBookings;
        }

        public Booking FindByRoom(int roomNo)
        {
            foreach (Booking b in dataAccess.LoadAll())
            {
                if (b.RoomNo == roomNo)
                    return b;
            }
            return null;
        }

        public Booking FindBookedByRoom(int roomNo)
        {
            foreach (Booking b in dataAccess.LoadAll())
            {
                if (b.RoomNo == roomNo && b.Booked)
                    return b;
            }
            return null;
        }

        public Booking FindByRoomAndName(int roomNo, string name)
        {
            foreach (Booking b in dataAccess.LoadAll())
            {
                if (b.RoomNo == roomNo && b.Customer.Name == name && b.Booked)
                    return b;
            }
            return null;
        }

        public bool IsRoomBooked(int roomNo)
        {
            return FindBookedByRoom(roomNo) != null;
        }

        public List<Booking> GetByName(string name)
        {
            List<Booking> result = new List<Booking>();
            foreach (Booking b in dataAccess.LoadAll())
            {
                if (b.Customer.Name == name)
                    result.Add(b);
            }
            return result;
        }

        public List<Booking> GetBookedByName(string name)
        {
            List<Booking> result = new List<Booking>();
            foreach (Booking b in dataAccess.LoadAll())
            {
                if (b.Customer.Name == name && b.Booked)
                    result.Add(b);
            }
            return result;
        }

        public Booking Add(int roomNo, string name, int days, float rent)
        {
            List<Booking> list = dataAccess.LoadAll();

            Customer c = new Customer(name);
            Booking b = new Booking(roomNo, c, days, rent);

            list.Add(b);
            dataAccess.SaveAll(list);
            return b;
        }

        public bool DeleteByRoom(int roomNo)
        {
            List<Booking> list = dataAccess.LoadAll();

            foreach (Booking b in list)
            {
                if (b.RoomNo == roomNo)
                {
                    list.Remove(b);
                    dataAccess.SaveAll(list);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteByRoomAndName(int roomNo, string name)
        {
            List<Booking> list = dataAccess.LoadAll();

            foreach (Booking b in list)
            {
                if (b.RoomNo == roomNo && b.Customer.Name == name && b.Booked)
                {
                    list.Remove(b);
                    dataAccess.SaveAll(list);
                    return true;
                }
            }
            return false;
        }

        public bool AdminUpdate(int roomNo, string newName, int newDays, float newRent)
        {
            List<Booking> list = dataAccess.LoadAll();

            foreach (Booking b in list)
            {
                if (b.RoomNo == roomNo && b.Booked)
                {
                    b.Customer.Name = newName;
                    b.Days = newDays;
                    b.Rent = newRent;

                    dataAccess.SaveAll(list);
                    return true;
                }
            }
            return false;
        }

        public bool CanMoveToRoom(int oldRoom, int newRoom)
        {
            if (newRoom == oldRoom)
                return true;

            return !IsRoomBooked(newRoom);
        }

        public Booking UpdateRoomAndDays(int oldRoom, string name, int newRoom, int newDays)
        {
            List<Booking> list = dataAccess.LoadAll();

            foreach (Booking b in list)
            {
                if (b.RoomNo == oldRoom && b.Customer.Name == name && b.Booked)
                {
                    b.RoomNo = newRoom;
                    b.Days = newDays;

                    dataAccess.SaveAll(list);
                    return b;
                }
            }
            return null;
        }

        public float GetTotalRevenue()
        {
            float total = 0;
            foreach (Booking b in dataAccess.LoadAll())
            {
                if (b.Booked)
                    total = total + b.Total;
            }
            return total;
        }

        public float GetBill(string name)
        {
            float total = 0;
            foreach (Booking b in GetBookedByName(name))
            {
                total = total + b.Total;
            }
            return total;
        }
    }
}
