using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLYSV
{
    public partial class Khoa : Form
    {
        private string connStr = ConfigurationManager.ConnectionStrings["QLYSV1"].ConnectionString;
        public Khoa()
        {
            InitializeComponent();
        }

        private void Khoa_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sqlText = "SELECT MAKHOA, TENKHOA FROM KHOA";
            SqlCommand cmd = new SqlCommand(sqlText, conn);
            lstnKHOA.Items.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                lstnKHOA.Items.Add(reader["MAKHOA"].ToString());
                lstnKHOA.Items[i].SubItems.Add(reader["TENKHOA"].ToString());
                i++;
            }
            //Conn.Close();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                try
                {
                    string MAKHOA = txtMaKhoa.Text;
                    string TENKHOA = txtTenKhoa.Text;
                    string sqlText = "INSERT  KHOA (  MAKHOA,TENKHOA)";
                    using (SqlCommand cmd = new SqlCommand(sqlText, conn))
                    {
                        cmd.Parameters.AddWithValue("@MKHOA", MAKHOA);
                        cmd.Parameters.AddWithValue("TENKHOA", TENKHOA);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection coon = new SqlConnection(connStr))
            {
                coon.Open();
                try
                {
                    string MAKHOA = txtMaKhoa.Text;
                    string TENKHOA = txtTenKhoa.Text;
                    string sqlText = "INSERT  KHOA (  MAKHOA,TENKHOA)";
                    using (SqlCommand cmd = new SqlCommand(sqlText, coon))
                    {
                        cmd.Parameters.AddWithValue("@MKHOA", MAKHOA);
                        cmd.Parameters.AddWithValue("TENKHOA", TENKHOA);
                        string cout = (string)cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";
        }

        private void lstnKHOA_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
