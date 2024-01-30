using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
namespace QLPT
{
    public partial class PhongTroControl1 : UserControl
    {
        public PhongTroControl1()
        {
            InitializeComponent();
            dgvDanhSachPhong_Load();
            DisablePhongTroControls();
        }
        private void DisablePhongTroControls()
        {
            txtMaPhong.Enabled = false;
            txtTenPhong.Enabled = false;
            txtGiaPhong.Enabled = false;
            cbbTrangThai.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void dgvDanhSachPhong_Load()
        {
            string sql = "select* from Phong";
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.ExecuteQuery(sql);
            dgvDanhSachPhong.DataSource = dt;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        int ChucNang = 0;
        private void btnThem_Click(object sender, EventArgs e)
        {
            ChucNang = 1;
            txtMaPhong.Enabled = true;
            txtTenPhong.Enabled = true;
            txtGiaPhong.Enabled = true;
            cbbTrangThai.Enabled = true;

            btnLuu.Enabled = true;
            btnSua.Enabled = false; 
            btnXoa.Enabled = false;
            Reset_PhongTro_data();
        }

        private void TimKiemTheoMaPhong(string maPhong)
        {
            string sql = "SELECT * FROM Phong WHERE MaPhong LIKE '%' + @maPhong + '%'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(sql, new object[] { maPhong });

            dgvDanhSachPhong.DataSource = dt;
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // lay du lieu
            string maPhongCanTim = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(maPhongCanTim))
            {
                MessageBox.Show("Vui lòng nhập mã phòng cần tìm kiếm!");
                return;
            }
            TimKiemTheoMaPhong(maPhongCanTim);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string currentSearchText = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(currentSearchText))
            {
                dgvDanhSachPhong_Load();
            }
            else
            {
                TimKiemTheoMaPhong(currentSearchText);
            }
        }
     

        private void btnSua_Click(object sender, EventArgs e)
        {
            ChucNang = 2;
            txtMaPhong.Enabled = false;
            txtTenPhong.Enabled = true;
            txtGiaPhong.Enabled = true;
            cbbTrangThai.Enabled = true;

            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void Reset_PhongTro_data()
        {
            txtMaPhong.Text = txtTenPhong.Text = txtGiaPhong.Text = cbbTrangThai.Text = txtTimKiem.Text = "";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Reset_PhongTro_data();
            DisablePhongTroControls();
        }
        private void XoaPhongTro(string maPhong)
        {
            try
            {
                string sql = "DELETE FROM Phong WHERE MaPhong = @maPhong";
                object[] parameters = { maPhong };
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(sql, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Đã xóa phòng thành công!");
                    dgvDanhSachPhong_Load();
                    Reset_PhongTro_data();
                }
                else
                {
                    MessageBox.Show("Không thể xóa phòng. Vui lòng kiểm tra lại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maPhongCanXoa = txtMaPhong.Text.Trim();

            if (string.IsNullOrEmpty(maPhongCanXoa))
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                XoaPhongTro(maPhongCanXoa);
            }
            else
            {

            }
        }

        private void PhongTroControl1_Load(object sender, EventArgs e)
        {
            dgvDanhSachPhong_Load();
            LoadDataForComboBoxTrangThai();
            DisablePhongTroControls();
            txtGiaPhong.KeyPress += new KeyPressEventHandler(txtGiaPhong_KeyPress);

        }

        private void dgvDanhSachPhong_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvDanhSachPhong.CurrentRow.Index;
            txtMaPhong.Text = dgvDanhSachPhong.Rows[i].Cells[0].Value.ToString().Trim();
            txtTenPhong.Text = dgvDanhSachPhong.Rows[i].Cells[1].Value.ToString().Trim();
            txtGiaPhong.Text = dgvDanhSachPhong.Rows[i].Cells[2].Value.ToString().Trim();
            cbbTrangThai.Text = dgvDanhSachPhong.Rows[i].Cells[3].Value.ToString().Trim();
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void dgvDanhSachPhong_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvDanhSachPhong.CurrentRow.Index;
            txtMaPhong.Text = dgvDanhSachPhong.Rows[i].Cells[0].Value.ToString().Trim();
            txtTenPhong.Text = dgvDanhSachPhong.Rows[i].Cells[1].Value.ToString().Trim();
            txtGiaPhong.Text = dgvDanhSachPhong.Rows[i].Cells[2].Value.ToString().Trim();
            cbbTrangThai.Text = dgvDanhSachPhong.Rows[i].Cells["TrangThai"].Value?.ToString().Trim() ?? "";
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void LoadDataForComboBoxTrangThai()
        {
            string sql = "SELECT DISTINCT TrangThai FROM Phong";
            DataTable dt = DataProvider.Instance.ExecuteQuery(sql);
            cbbTrangThai.DataSource = dt;
            cbbTrangThai.DisplayMember = "TrangThai";
            cbbTrangThai.ValueMember = "TrangThai";
        }
        private bool IsValidData()
        {
            if (string.IsNullOrWhiteSpace(txtMaPhong.Text) ||
                string.IsNullOrWhiteSpace(txtTenPhong.Text) ||
                string.IsNullOrWhiteSpace(txtGiaPhong.Text) ||
                string.IsNullOrWhiteSpace(cbbTrangThai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return false;
            }

            if (ChucNang == 1 && !IsMaPhongUnique(txtMaPhong.Text.Trim()))
            {
                MessageBox.Show("Mã phòng đã tồn tại. Vui lòng chọn mã phòng khác!");
                return false;
            }

            if (ChucNang == 1 && !IsTenPhongUnique(txtTenPhong.Text.Trim()))
            {
                MessageBox.Show("Tên phòng đã tồn tại. Vui lòng chọn tên phòng khác!");
                return false;
            }

            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!IsValidData())
            {
                return;
            }

            try
            {
                string connectionString = "Data Source=SHEN\\MSSQLSERVER02;Initial Catalog=quanlynhatro;Integrated Security=True;Encrypt=False";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();

                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.CommandType = CommandType.Text;

                        if (ChucNang == 1) // Thêm
                        {
                            sqlCmd.CommandText = "INSERT INTO Phong (MaPhong, TenPhong, GiaPhong, TrangThai) VALUES (@maPhongInsert, @tenPhong, @giaPhong, @trangThai)";
                        }
                        else if (ChucNang == 2) // Sửa
                        {
                            sqlCmd.CommandText = "UPDATE Phong SET TenPhong=@tenPhong, GiaPhong=@giaPhong, TrangThai=@trangThai WHERE MaPhong=@maPhongUpdate";
                            sqlCmd.Parameters.AddWithValue("@maPhongUpdate", txtMaPhong.Text.Trim());
                        }

                        sqlCmd.Parameters.AddWithValue("@maPhongInsert", txtMaPhong.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@tenPhong", txtTenPhong.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@giaPhong", txtGiaPhong.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@trangThai", cbbTrangThai.Text.Trim());

                        sqlCmd.Connection = sqlCon;

                        // Thực thi truy vấn
                        int kq = sqlCmd.ExecuteNonQuery();

                        if (kq > 0)
                        {
                            if (ChucNang == 1)
                            {
                                MessageBox.Show("Thêm phòng thành công!");
                            }
                            else if (ChucNang == 2)
                            {
                                MessageBox.Show("Cập nhật phòng thành công!");
                            }

                            dgvDanhSachPhong_Load();
                            Reset_PhongTro_data();
                            DisablePhongTroControls();
                        }
                        else
                        {
                            if (ChucNang == 1)
                            {
                                MessageBox.Show("Thêm phòng thất bại!");
                            }
                            else if (ChucNang == 2)
                            {
                                MessageBox.Show("Cập nhật phòng thất bại!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void txtGiaPhong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Nếu không phải là số, không cho phép nhập
            }
        }
        private bool IsMaPhongUnique(string maPhong)
        {
            string sql = "SELECT COUNT(*) FROM Phong WHERE MaPhong = @maPhong";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(sql, new object[] { maPhong }));

            return count == 0;
        }

        private bool IsTenPhongUnique(string tenPhong)
        {
            string sql = "SELECT COUNT(*) FROM Phong WHERE TenPhong = @tenPhong";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(sql, new object[] { tenPhong }));

            return count == 0;
        }
    }
}


