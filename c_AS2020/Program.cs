using System;
using taxiModel;

namespace c_AS2020
{
    class Program
    {
        static void Main(string[] args)
        {
            taxiContext.SetConnectionString("Host=localhost;Database=taxi;Username=taxi_driver;Password=1");
            using (taxiContext tc = new taxiContext())
            {
                UserSave users = new UserSave();
                users.SetHashPassword("OpenPassword");
                UserSave.CheckUser("Email", "OpenPassword");
                UserSave.GetUser("Email");
            }
        }
    }
}
