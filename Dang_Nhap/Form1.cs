using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Dang_Nhap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            SqlConnection comn = new SqlConnection(@"Data Source=DESKTOP-3QHMVMG\SQLEXPRESS;Initial Catalog=QUANLYKHACHSAN;Integrated Security=True");
            
                try
                {
                    comn.Open();
                SqlCommand commd = new SqlCommand("Dangnhap", comn);
                commd.CommandType = CommandType.StoredProcedure;
                commd.Parameters.Add("@tenDN", SqlDbType.NVarChar).Value = txtTenDangNhap.Text;
                commd.Parameters.Add("@password", SqlDbType.NVarChar).Value = txtMatKhau.Text;
                comn.InfoMessage += conn_InfoMessage;
                commd.ExecuteNonQuery();
                comn.Close();
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Init exit = new Init();
            exit.Show();
            this.Hide();
        }
    }
}
