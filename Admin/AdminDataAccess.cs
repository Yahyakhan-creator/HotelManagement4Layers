using System;
using System.IO;

namespace HotelManagement
{
    class AdminDataAccess
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "admin.txt");

        public Admin LoadAdmin()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "admin|1234");
            }

            string line = File.ReadAllText(filePath).Trim();
            string[] parts = line.Split('|');

            Admin admin = new Admin("Hotel Admin", parts[0], parts[1]);
            return admin;
        }
    }
}
