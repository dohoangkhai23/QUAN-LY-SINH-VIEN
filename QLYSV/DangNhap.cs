using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace QLYSV
{
    public partial class DangNhap : Form
    {
        private string connStr = ConfigurationManager.ConnectionStrings["QLSV1"].ConnectionString;
        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                try
                {
                    string MASV = txtMASV.Text;
                    string MATKHAU = txtMatKhau.Text;
                    string sqlText = "SELECT * FROM DANGNHAP WHERE MASV = @MASV AND MATKHAU = @MATKHAU";
                    using (SqlCommand cmd = new SqlCommand(sqlText, conn))
                    {
                        cmd.Parameters.AddWithValue("@MASV", MASV);
                        cmd.Parameters.AddWithValue("@MATKHAU", MATKHAU);
                        string cout = (string)cmd.ExecuteScalar();
                        if (!string.IsNullOrEmpty(cout))
                        {
                            
                            MessageBox.Show("Đăng Nhập Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            new QUAN_LY_SINH_VIEN().Show();
                            
                        }
                        else
                        {
                            MessageBox.Show("Đăng Nhập Không Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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
    }
}
