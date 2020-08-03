using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            string hash = "", salt = "";
            GetPasswordSalt(password, out hash, out salt);
            this.Hash = hash;
            this.Salt = salt;
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
        }

        public static bool CheckUser(string login, string password)
        {

            using (taxiContext tc = new taxiContext())
            {
                Users u = GetUser(login); 

                if (u == null) return false;

                return CheckPass(password, u.Hash, u.Salt);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public void SetNewId()
        {
            Seq q = new Seq();
            this.Id = q.GetSeq1();
        }

        static bool CheckPassord(string encodingPass, string Salt)
        {


            return true;
        }

        void SetPassword(string openPassord)
        {
            string sHash = "", sSalt = "";
            GetPasswordSalt(openPassord, out sHash, out sSalt);
            Hash = sHash;
            Salt = sSalt;
        }

        /// <summary>
        /// Получение по открытому параметру хешу и соли
        /// </summary>
        /// <param name="OpenPassword">Открытый пароль</param>
        /// <param name="Hash">Возвращаемый хеш от пароля</param>
        /// <param name="Salt">Соль, по которой сделан пароль</param>
        static void GetPasswordSalt(string OpenPassword, out string Hash , out string Salt)
        {
            byte[] salt = new byte[40];
            byte[] hashedPassword = null;

            using (Rfc2898DeriveBytes rngCsp = new Rfc2898DeriveBytes(OpenPassword, 40, 10))
            {
                hashedPassword = rngCsp.GetBytes(40);
                salt = rngCsp.Salt;
            }
            string pass = "", strSalt = "";
            for (int i = 0; i < 40; i++)
            {
                pass += (char)hashedPassword[i];
                strSalt += (char)salt[i];
            }
            Hash = pass;
            Salt = strSalt;
        }

        static bool CheckPass(string OpenPassowrd, string Hash, string Salt)
        {
            byte[] bSalt = new byte[40], bPass;
            for(int i = 0; i < 40; i++)
            {
                bSalt[i] = (byte)Salt[i];
            }

            using (Rfc2898DeriveBytes rngCsp = new Rfc2898DeriveBytes(OpenPassowrd, bSalt))
            {
                bPass = rngCsp.GetBytes(40);
            }

            for(int i = 0; i < 40; i++)
            {
                if (bPass[i] != (byte)Hash[i]) 
                    return false;
            }

            return true;
        }
    }
}
