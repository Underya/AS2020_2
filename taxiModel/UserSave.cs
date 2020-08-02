using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace taxiModel
{
    /// <summary>
    /// Сохранение информации о пользователе в виде соли
    /// </summary>
    public class UserSave : Users
    {
        /// <summary>
        /// Сохранение пароля как 
        /// </summary>
        /// <param name="password"></param>
        public void SetHashPassword(string password)
        {
            Hash = GetHashPassword(password);
        }

        public static string s0(string s)
        {
            string ns = "";
            int lastNotNull = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ') lastNotNull = i;
            }

            return s.Substring(0, lastNotNull + 1);
        }

        public UserSave(Users user)
        {
            SetInfoUser(user);
        }

        public void Refresh()
        {
            Users users = UserSave.GetUser(Email);
            SetInfoUser(users);
        }

        /// <summary>
        /// Загрузка всех связанных объектов
        /// </summary>
        void Load()
        {
            using(taxiContext c = new taxiContext())
            {
                c.Attach((Users)this);
                c.Entry(this).Collection(t=>t.Ur).Load();
                //И для всех элментов подзагрузка

            }
        }

        public List<Roles> Roles { get; set; }
        public List<Function> Functions { get; set; }
        public void LoadRoleFunction()
        {
            Load();
            LoadRole();
            LoadFunction();
        }

        void LoadRole()
        {
            List<Roles> roles = new List<Roles>();
            using (taxiContext tc = new taxiContext())
            {
                
                foreach (Ur link in Ur)
                {
                    tc.Attach(link);
                    tc.Entry(link).Reference(z => z.IdrolesNavigation).Load();
                    roles.Add(link.IdrolesNavigation);
                }
            }

            this.Roles = roles;
        }

        void LoadFunction()
        {
            List<Function> functions = new List<Function>();
            using (taxiContext tc = new taxiContext())
            {
                foreach(Roles role in Roles)
                {
                    tc.Attach(role);
                    tc.Entry(role).Collection(t => t.Rf).Load();
                    foreach(Rf rf in role.Rf)
                    {
                        tc.Attach(rf);
                        tc.Entry(rf).Reference(t => t.IdfunctionNavigation).Load();
                        functions.Add(rf.IdfunctionNavigation);
                    }
                }
            }

            Functions = functions;
        }

        void SetInfoUser(Users user)
        {
            this.Firstname = user.Firstname;
            this.Datebirth = user.Datebirth;
            this.Lastname = user.Lastname;
            this.Midname = user.Midname;
            this.Number = user.Number;
            this.Email = user.Email;
            this.Hash = user.Hash;
            this.Sex = user.Sex;
            this.Ur = user.Ur;
            this.Id = user.Id;
        }

        public UserSave()
        {

        }

        public static UserSave GetUser (string login)
        {
            using (taxiContext tc = new taxiContext())
            {
                UserSave us = null; 
                us = new UserSave( tc.Users.Where(p => p.Email == login).FirstOrDefault());
                return us;
            }

            return null;
        }

        public static bool CheckUser(string login, string password)
        {

            using (taxiContext tc = new taxiContext())
            {
                Users u = GetUser(login); 

                if (u == null) return false;

                string oldHash = u.Hash;

                string newHash = GetHashPassword(password);

                for(int i = 0; i < 20; i++)
                {
                    if (oldHash[i] != newHash[i]) return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetNewId()
        {
            Seq q = new Seq();
            this.Id = q.GetSeq1();
        }

        static string GetHashPassword(string openPassord)
        {
            byte[] salt = new byte[8] { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] hashedPassword = null;

            using (Rfc2898DeriveBytes rngCsp = new Rfc2898DeriveBytes(openPassord, salt))
            {
                hashedPassword = rngCsp.GetBytes(20);
            }
            string ret = "";
            foreach(byte b in hashedPassword)
            {
                ret += (char)b;
            }
            return ret;
        }
    }
}
