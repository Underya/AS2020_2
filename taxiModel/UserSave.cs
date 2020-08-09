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
        /// Сохранение пароля в закрытом виде
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

        /// <summary>
        /// Загрузка всех ролей и функций, связанных с пользователем
        /// </summary>
        public void LoadRoleFunction()
        {
            Load();
            LoadRole();
            LoadFunction();
        }

        /// <summary>
        /// Загрузка связанных ролей
        /// </summary>
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

        /// <summary>
        /// Загрузка функций, связанных с ролью
        /// </summary>
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

        /// <summary>
        /// Получение информации из базового объекта
        /// </summary>
        /// <param name="user"></param>
        void SetInfoUser(Users user)
        {
            this.Firstname = user.Firstname;
            this.Datebirth = user.Datebirth;
            this.Lastname = user.Lastname;
            this.Midname = user.Midname;
            this.Number = user.Number;
            this.Email = user.Email;
            this.Salt = user.Salt;
            this.Hash = user.Hash;
            this.Sex = user.Sex;
            this.Ur = user.Ur;
            this.Id = user.Id;
        }

        /// <summary>
        /// Создание пустого объекта
        /// </summary>
        public UserSave()
        {

        }

        /// <summary>
        /// Получение пользователя с указанным логином
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public static UserSave GetUser (string login)
        {
            using (taxiContext tc = new taxiContext())
            {
                UserSave us = null; 
                us = new UserSave( tc.Users.Where(p => p.Email == login).FirstOrDefault());
                return us;
            }
        }

        /// <summary>
        /// Проверка, есть ли пользователь с таким логиным и паролем
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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
        /// Установка новогоуникального Id 
        /// </summary>
        public void SetNewId()
        {
            Seq q = new Seq();
            this.Id = q.GetSeq1();
        }

        /// <summary>
        /// Получение по открытому параметру хешу и соли
        /// </summary>
        /// <param name="OpenPassword">Открытый пароль</param>
        /// <param name="Hash">Возвращаемый хеш от пароля</param>
        /// <param name="Salt">Соль, по которой сделан пароль</param>
        static void GetPasswordSalt(string OpenPassword, out string Hash , out string Salt)
        {
            SaltGenerator sg = new SaltGenerator();
            sg.GetOpenPassword(OpenPassword, out Hash, out Salt);
        }

        /// <summary>
        /// Проверка открытого пароля на совпадание со старым паролем при указанной соли
        /// </summary>
        /// <param name="OpenPassword"></param>
        /// <param name="Hash"></param>
        /// <param name="Salt"></param>
        /// <returns></returns>
        static bool CheckPass(string OpenPassword, string Hash, string Salt)
        {
            SaltGenerator sg = new SaltGenerator();
            string hash2 = sg.GetHash(OpenPassword, Salt);
            return Hash == hash2;
        }
    }
}
