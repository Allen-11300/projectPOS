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

namespace nbi_inventory_pos_ver2
{
    public partial class frmProduct : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBconnect dbcon = new DBconnect();
        SqlDataReader dr;
        frmProductList flist;
        public frmProduct(frmProductList frm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            flist = frm;
        }

        public void LoadCategory()
        {
            cboCategory.Items.Clear();
            cn.Open();
            cm = new SqlCommand("select category from dbo.tbl_category", cn);
            dr = cm.ExecuteReader();
            while(dr.Read())
            {
                cboCategory.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cn.Close();
        }

        public void LoadBrand()
        {
            cboBrand.Items.Clear();
            cn.Open();
            cm = new SqlCommand("select brand from dbo.tbl_brand", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cboBrand.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {

        }

        public void Clear()
        {
            txtPrice.Clear();
            txtPdesc.Clear();
            txtPcode.Clear();
            txtBarcode.Clear();
            cboBrand.Text = " ";
            cboCategory.Text = " ";
            txtPcode.Focus();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Confirm Save?", "Save Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    string bid = " "; string cid = " ";
                    cn.Open();
                    cm = new SqlCommand("Select id from dbo.tbl_brand where brand like '" + cboBrand.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if(dr.HasRows)
                    {
                        bid = dr[0].ToString();
                    }
                    dr.Close();
                    cn.Close();

                    cn.Open();
                    cm = new SqlCommand("Select id from dbo.tbl_category where category like '" + cboCategory.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        cid = dr[0].ToString();
                    }
                    dr.Close();
                    cn.Close();

                    cn.Open();
                    cm = new SqlCommand("Insert into dbo.tbl_product (pcode, barcode, pdesc, bid, cid, price) VALUES(@pcode, @barcode, @pdesc, @bid, @cid, @price)", cn);
                    cm.Parameters.AddWithValue("@pcode", txtPcode.Text);
                    cm.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                    cm.Parameters.AddWithValue("@pdesc", txtPdesc.Text);
                    cm.Parameters.AddWithValue("@bid", bid);
                    cm.Parameters.AddWithValue("@cid", cid);
                    cm.Parameters.AddWithValue("@price", txtPrice.Text);
                    cm.ExecuteNonQuery();  
                    cn.Close();
                    MessageBox.Show("Product Successfully Saved");
                    Clear();
                    flist.LoadRecords();
                }
            }catch(Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirm Update", "Update Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string bid = " "; string cid = " ";
                    cn.Open();
                    cm = new SqlCommand("Select id from dbo.tbl_brand where brand like '" + cboBrand.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        bid = dr[0].ToString();
                    }
                    dr.Close();
                    cn.Close();

                    cn.Open();
                    cm = new SqlCommand("Select id from dbo.tbl_category where category like '" + cboCategory.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        cid = dr[0].ToString();
                    }
                    dr.Close();
                    cn.Close();

                    cn.Open();
                    cm = new SqlCommand("UPDATE dbo.tbl_product SET barcode=@barcode, pdesc=@pdesc, bid=@bid, cid=@cid, price=@price where pcode like @pcode", cn);
                    cm.Parameters.AddWithValue("@pcode", txtPcode.Text);
                    cm.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                    cm.Parameters.AddWithValue("@pdesc", txtPdesc.Text);
                    cm.Parameters.AddWithValue("@bid", bid);
                    cm.Parameters.AddWithValue("@cid", cid);
                    cm.Parameters.AddWithValue("@price", txtPrice.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Product Successfully Updated");
                    Clear();
                    flist.LoadRecords();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        //private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if(e.KeyChar==48)
        //    {

        //    }
        //    else if(e.KeyChar==8)
        //    {

        //    }
        //    if((e.KeyChar<48)||(e.KeyChar>57))
        //    {
        //        e.Handled=true;
        //    }
        //}

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
