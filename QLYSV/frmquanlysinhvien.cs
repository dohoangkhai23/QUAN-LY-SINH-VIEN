using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLYSV
{
    public partial class frmquanlysinhvien : Form
    {
        public frmquanlysinhvien()
        {
            InitializeComponent();
        }
        private string connStr = ConfigurationManager.ConnectionStrings["QLYSV1"].ConnectionString;
        private void frmquanlysinhvien_Load(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sqlText = "SELECT MASV,HOTEN,NGAYSINH,SODIENTHOAI,GIOITINH FROM SINHVIEN";
            SqlCommand cmd = new SqlCommand(sqlText, conn);
            listSINHVIEN.Items.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                listSINHVIEN.Items.Add(reader["MASV"].ToString());
                listSINHVIEN.Items[i].SubItems.Add(reader["HOTEN"].ToString());
                listSINHVIEN.Items[i].SubItems.Add(reader["NGAYSINH"].ToString());
                listSINHVIEN.Items[i].SubItems.Add(reader["SODIENTHOAI"].ToString());
                listSINHVIEN.Items[i].SubItems.Add(reader["GIOITINH"].ToString());
                i++;
            }
            //Conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                try
                {
                    
                        string MASV = txtMaSV.Text;
                        string HOTEN = txtHoTen.Text;
                        string NGAYSINH = txtNgaySinh.Text;
                        string SODIENTHOAI = txtDienThoai.Text;
                        string DIACHI = txtDiaChi.Text;
                        string GIOITINH = groupBoxGioiTinh.Text;
                        string sqlText = "INSERT SINHVIEN (  MASV,HOTEN,NGAYSINH,DIENTHOAI,DIACHI,GIOITINH)";
                        using (SqlCommand cmd = new SqlCommand(sqlText, conn))
                        {
                         cmd.Parameters.AddWithValue("@MASV", MASV);
                         cmd.Parameters.AddWithValue("@HOTEN", HOTEN);
                        cmd.Parameters.AddWithValue("@NGAYSINH", NGAYSINH);
                        cmd.Parameters.AddWithValue("@DIENTHOAI", SODIENTHOAI);
                        cmd.Parameters.AddWithValue("@DIACHI", DIACHI);
                        cmd.Parameters.AddWithValue("@GIOITINH", GIOITINH);
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
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                try
                {
                    string MASV = txtMaSV.Text;
                    string HOTEN = txtHoTen.Text;
                    string NGAYSINH = txtNgaySinh.Text;
                    string SODIENTHOAI = txtDienThoai.Text;
                    string DIACHI = txtDiaChi.Text;
                    string GIOITINH = groupBoxGioiTinh.Text;
                    string sqlText = "INSERT SINHVIEN (  MASV,HOTEN,NGAYSINH,DIENTHOAI,DIACHI,GIOITINH)";
                    using (SqlCommand cmd = new SqlCommand(sqlText, conn))
                    {
                        cmd.Parameters.AddWithValue("@MASV", MASV);
                        cmd.Parameters.AddWithValue("@HOTEN", HOTEN);
                        cmd.Parameters.AddWithValue("@NGAYSINH", NGAYSINH);
                        cmd.Parameters.AddWithValue("@DIENTHOAI", SODIENTHOAI);
                        cmd.Parameters.AddWithValue("@DIACHI", DIACHI);
                        cmd.Parameters.AddWithValue("@GIOITINH", GIOITINH);
                        string cout = (string)cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Thông Báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMaSV.Text = "";
            txtHoTen.Text = "";
            txtNgaySinh.Text = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";
            groupBoxGioiTinh.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn =  new SqlConnection(connStr))
            {
                conn.Open();
                try
                {
                    string MASV = txtMaSV.Text;
                    string HOTEN = txtHoTen.Text;
                    string NGAYSINH = txtNgaySinh.Text;
                    string SODIENTHOAI = txtDienThoai.Text;
                    string DIACHI = txtDiaChi.Text;
                    string GIOITINH = groupBoxGioiTinh.Text;
                    string sqlText = "INSERT SINHVIEN (  MASV,HOTEN,NGAYSINH,DIENTHOAI,DIACHI,GIOITINH)";
                    using (SqlCommand cmd = new SqlCommand(sqlText, conn))
                    {
                        cmd.Parameters.AddWithValue("@MASV", MASV);
                        cmd.Parameters.AddWithValue("@HOTEN", HOTEN);
                        cmd.Parameters.AddWithValue("@NGAYSINH", NGAYSINH);
                        cmd.Parameters.AddWithValue("@DIENTHOAI", SODIENTHOAI);
                        cmd.Parameters.AddWithValue("@DIACHI", DIACHI);
                        cmd.Parameters.AddWithValue("@GIOITINH", GIOITINH);
                        string cout = (string)cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
    
}
       
           
        

