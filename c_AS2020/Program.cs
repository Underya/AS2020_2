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
            SaltGenerator generate = new SaltGenerator();
            byte[] hash1 = null, salt1 = null, hash2 = null;
            string shash1 = "", shash2 = "", ssalt = "";
            string pass = "OpenPassword";
            generate.GetOpenPassword(pass, out shash1, out ssalt);
            shash2 =  generate.GetHash(pass, ssalt);
            return;
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
