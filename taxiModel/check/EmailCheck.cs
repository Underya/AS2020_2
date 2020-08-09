using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace taxiModel.check
{
    /// <summary>
    /// Проверка соотвествия строки шаблону Email
    /// </summary>
    public class EmailCheck
    {
        /// <summary>
        /// Проверка соотвествия шаблону Email
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public bool Check(string Email)
        {
            return Regex.IsMatch(Email.ToLower(), "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}", RegexOptions.IgnoreCase);
        }
    }
}
