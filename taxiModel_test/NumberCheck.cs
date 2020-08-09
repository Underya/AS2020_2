using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace taxiModel.check
{
    public class NumberCheck
    {
        public bool Check(string Number)
        {
            return Regex.IsMatch(Number, "\\d \\d\\d\\d-\\d\\d\\d-\\d\\d\\d\\d");
        }
    }
}
