using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLYSV
{
    public partial class NganhHoc : Form
    {
        private string connStr = ConfigurationManager.ConnectionStrings["QLYSV1"].ConnectionString;
        public NganhHoc()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                try
                {

                    string MANGANH = txtMaNganh.Text;
                    string TENNGANH = txtTenNganh.Text;
                    string MAKHOA = txtMaKhoa.Text;
                    string sqlText = "INSERT NGANHHOC  ( MANGANH,TENNGANH,MAKHOA)";
                    using (SqlCommand cmd = new SqlCommand(sqlText, conn))
                    {
                        cmd.Parameters.AddWithValue("@MANGANH", MANGANH);
                        cmd.Parameters.AddWithValue("@TENNGANH", TENNGANH);
                        cmd.Parameters.AddWithValue("@MAKHOA", MAKHOA);
                        string cout = (string)cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    {
                        MessageBox.Show($"Lỗi: {ex.Message}", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void NganhHoc_Load(object sender, EventArgs e)
        {
            layData();
        }

        public void layData()
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sqlText = "SELECT MANGANH, TENNGANH, MAKHOA FROM NGANHHOC";
            SqlCommand cmd = new SqlCommand(sqlText, conn);
            listNganhHoc.Items.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                listNganhHoc.Items.Add(reader["MANGANH"].ToString());
                listNganhHoc.Items[i].SubItems.Add(reader["TENNGANH"].ToString());
                listNganhHoc.Items[i].SubItems.Add(reader["MAKHOA"].ToString());
                i++;
            }
            //Conn.Close();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                try
                {

                    string MANGANH = txtMaNganh.Text;
                    string TENNGANH = txtTenNganh.Text;
                    string MAKHOA = txtMaKhoa.Text;
                    string sqlText = "SELECT NGANHHOC (MANGANH,TENNGANH,MAKHOA)";
                    using (SqlCommand cmd = new SqlCommand(sqlText, conn))
                    {
                        cmd.Parameters.AddWithValue("@MANGANH", MANGANH);
                        cmd.Parameters.AddWithValue("@TENNGANH", TENNGANH);
                        cmd.Parameters.AddWithValue("@MAKHOA", MAKHOA);
                        string cout = (string)cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    {
                        MessageBox.Show($"Lỗi: {ex.Message}", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMaKhoa.Text = "";
            txtTenNganh.Text = "";
            txtMaKhoa.Text = "";
        }
    }
}