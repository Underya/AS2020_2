using System;
using System.Dynamic;
using taxiModel;

namespace c_AS2020
{
    class Program
    {
        static void Main(string[] args)
        {
            taxiModel.check.EmailCheck c = new taxiModel.check.EmailCheck();
            bool ret = c.Check("dawdd@dawd.ru");
            ret = c.Check("dawdd@dawd.ru");
            ret = c.Check("123dawdd@dawd.ru");
            ret = c.Check("324212d@d113a231wd.r123u");
            ret = c.Check("d.dawd.adw.dwa.awdd@dawdawdd.dru");
            ret = c.Check("@dawd.ru");
            ret = c.Check("dawdd@.ru");
            ret = c.Check("dawdd@dawd.");
        }
    }
}
