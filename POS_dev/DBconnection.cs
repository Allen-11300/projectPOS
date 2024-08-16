using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_dev
{
     class DBconnection
    {
        public string MyConnection()
        {
            string con = @"Data Source=DESKTOP-0NUDK9I;Initial Catalog=POSdb;Integrated Security=True";
            return con;
        }
    }
}
