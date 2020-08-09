using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace taxiModel_test
{
    public class NumberCheck
    {
        public bool Check(string Number)
        {
            return Regex.IsMatch(Number, "([0-9]){1}");
        }
    }
}
