using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace taxiModel_test
{
    /// <summary>
    /// Проверка соответсвия номера телеофна шаблону 9 999-999-9999
    /// </summary>
    public class NumberCheck
    {
        /// <summary>
        /// Проверка соотвествия строки шаблону 9 999-999-9999
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public bool Check(string Number)
        {
            if (Number.Length != 14) 
                return false;
            return Regex.IsMatch(Number, @"\d{1} \d{3}-\d{3}-\d{4}");
        }
    }
}
