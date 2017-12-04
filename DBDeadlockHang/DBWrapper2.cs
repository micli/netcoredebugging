using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBDeadlockHang
{
    class DBWrapper2
    {
        private string connectionString;

        public DBWrapper2(string conStr)
        {
            this.connectionString = conStr;
        }
    }
}
