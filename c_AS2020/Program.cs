using System;
using System.Dynamic;
using taxiModel;
using taxiModel_test;

namespace c_AS2020
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberCheck numberCheck = new NumberCheck();
            bool res = true;
            res = numberCheck.Check("1");
            res = numberCheck.Check("12");
            res = numberCheck.Check("123");
            res = numberCheck.Check("1234");
        }
    }
}
