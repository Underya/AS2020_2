using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace taxiModel
{
    public class Seq
    {
        public int GetSeq1()
        {
            int res = 0;
            string str = taxiContext.GetConnectionString();
            using (NpgsqlConnection c = new NpgsqlConnection(str))
            {
                c.Open();
                using (NpgsqlCommand comm = c.CreateCommand())
                {
                    comm.CommandText = "select nextval('s1')";
                    object a = comm.ExecuteScalar();
                    res = (int)(Int64)a;
                }
            }
            return res;
        }
    }
}
