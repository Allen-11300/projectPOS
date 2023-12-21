using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nbi_inventory_pos_ver2
{
    internal class DBconnect
    {
        public string MyConnection()
        {
            string con = "Data Source=AMD\\SQLEXPRESS;Initial Catalog=inventoryNBI;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            return con;
        }
    }
}
