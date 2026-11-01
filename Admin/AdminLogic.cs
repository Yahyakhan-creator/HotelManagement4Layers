namespace HotelManagement
{
    class AdminLogic
    {
        AdminDataAccess dataAccess = new AdminDataAccess();

        public bool Login(string user, string pass)
        {
            Admin admin = dataAccess.LoadAdmin();

            if (user == admin.Username && pass == admin.Password)
                return true;
            else
                return false;
        }
    }
}
