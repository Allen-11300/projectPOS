using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_dev
{
    public partial class mainPOS : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBconnection dbcon = new DBconnection();
        public mainPOS()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            cn.Open();
            MessageBox.Show("Connected");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainPOS_Load(object sender, EventArgs e)
        {

        }
    }
}
