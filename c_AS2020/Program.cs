using System;
using System.Dynamic;
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
                string str = "OpenPassword", email = "Email";
                bool result = UserSave.CheckUser(email, str);
                UserSave.GetUser(email);
            }
        }
    }
}
