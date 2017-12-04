using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBDeadlockHang
{
    class DBWrapper1
    {
        private string connectionString;

        public DBWrapper1(string conStr)
        {
            this.connectionString = conStr;
        }
    }
}
