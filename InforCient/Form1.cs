using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InforCient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection myConn = new SqlConnection(@"Data Source=DESKTOP-3QHMVMG\SQLEXPRESS;Initial Catalog=QUANLYKHACHSAN;Integrated Security=True");
            myConn.Open();
            try
            {
                SqlCommand myCmd = new SqlCommand("Find_InfClient", myConn);
                myCmd.Parameters.Add("@maKH", SqlDbType.NVarChar).Value = txtMaKH.Text;
                myCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(myCmd);
                da.Fill(dt);
                dtGrid.DataSource = dt;
                myConn.InfoMessage += conn_InfoMessage;
                myCmd.ExecuteNonQuery();
                txtMaKH.Clear();
            }catch(Exception ex)
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
            this.Hide();
        }
    }
}
