using System;
using taxiModel;

namespace c_AS2020
{
    class Program
    {
        static void Main(string[] args)
        {
            taxiContext.SetConnectionString("Host=localhost;Database=taxi;Username=taxi_driver;Password=1");
            using(taxiContext tc = new taxiContext())
            {
                Users users = new Users();
                users.Email = "dawd";
                users.Hash = "daw";
                users.Salt = "dawd";
                tc.Users.Add(users);
                tc.SaveChanges();
            }
        }
    }
}
