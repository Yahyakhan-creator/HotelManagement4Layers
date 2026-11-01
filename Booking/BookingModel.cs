namespace HotelManagement
{
    class Booking
    {
        private int roomNo;
        private Customer customer;
        private int days;
        private float rent;
        private bool booked;

        public int RoomNo
        {
            get { return roomNo; }
            set { roomNo = value; }
        }

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public int Days
        {
            get { return days; }
            set { days = value; }
        }

        public float Rent
        {
            get { return rent; }
            set { rent = value; }
        }

        public bool Booked
        {
            get { return booked; }
            set { booked = value; }
        }

        public float Total
        {
            get { return days * rent; }
        }

        public Booking(int roomNo, Customer customer, int days, float rent)
        {
            this.roomNo = roomNo;
            this.customer = customer;
            this.days = days;
            this.rent = rent;
            this.booked = true;
        }

        public override string ToString()
        {
            return roomNo + " " + customer.Name + " " + days + " " + rent;
        }
    }
}
