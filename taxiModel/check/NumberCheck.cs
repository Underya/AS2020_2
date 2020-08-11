using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace taxiModel_test
{
    public class NumberCheck
    {
        public bool Check(string Number)
        {
            if (Number.Length != 14) 
                return false;
            return Regex.IsMatch(Number, @"\d{1} \d{3}-\d{3}-\d{4}");
        }
    }
}
