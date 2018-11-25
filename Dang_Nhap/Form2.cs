using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;


namespace Dang_Nhap
{
    public partial class Form2 : Form
    {

 

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnDangki_Click(object sender, EventArgs e)
        {
           
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-3QHMVMG\SQLEXPRESS;Initial Catalog=QUANLYKHACHSAN;Integrated Security=True");

            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("check_re", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@hoten", SqlDbType.NVarChar).Value = txthoten.Text;
                comm.Parameters.Add("@tendangnhap", SqlDbType.NVarChar).Value = txtTenDN.Text;
                comm.Parameters.Add("@matkhau", SqlDbType.NVarChar).Value = txtpass.Text;
                comm.Parameters.Add("@confrimpass", SqlDbType.NVarChar).Value = txtconfirmpass.Text;
                comm.Parameters.Add("@socmnd", SqlDbType.NVarChar).Value = txtCMND.Text;
                comm.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = txtdiachi.Text;
                comm.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = txtSDT.Text;
                comm.Parameters.Add("@mota", SqlDbType.NVarChar).Value = txtmota.Text;
                comm.Parameters.Add("@email", SqlDbType.NVarChar).Value = txtEmail.Text;
                conn.InfoMessage += conn_InfoMessage;

                comm.ExecuteNonQuery();
                conn.Close();
               /* txthoten.Clear();
                txtTenDN.Clear();
                txtpass.Clear();
                txtCMND.Clear();
                txtdiachi.Clear();
                txtSDT.Clear();
                txtmota.Clear();
                txtEmail.Clear();
                txtconfirmpass.Clear();*/
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }
     
        }
        void conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            MessageBox.Show(e.Message); // e.Message để lấy message từ dưới sql gửi lên
        }
        public static void main(string[] arg)
        {
            Application.Run(new Form2());
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            Init init = new Init();
            init.Show();
            this.Hide();
        }
    }
}
