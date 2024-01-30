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

namespace QLPT
{
    public partial class KhachHangControl1 : UserControl
    {
        public KhachHangControl1()
        {
            InitializeComponent();
            dgvDanhSachKH_Load();
            DisableKhachHangControls();
        }
        private void DisableKhachHangControls()
        {
            // Vô hiệu hóa
            txtMaKH.Enabled = false;
            txtTenKH.Enabled = false;
            cbbGioiTinh.Enabled = false;
            txtSoDienThoai.Enabled = false;
            txtCanCuoc.Enabled = false;
            txtDiaChi.Enabled = false;
            cbbMaPhong.Enabled = false;
            txtTenPhong.Enabled = false;

            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void dgvDanhSachKH_Load()
        {
            string sql = "select* from KhachHang";
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.ExecuteQuery(sql);
            dgvDanhSachKH.DataSource = dt;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void TimKiemTheoMaKH(string maPhong)
        {
            string sql = "SELECT * FROM KhachHang WHERE MaKH LIKE '%' + @maKH + '%'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(sql, new object[] { maPhong });

            dgvDanhSachKH.DataSource = dt;
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Lay du lieu
            string maKHCanTim = txtTimKiem.Text.Trim();

            // Kiem tra rong
            if (string.IsNullOrEmpty(maKHCanTim))
            {
                MessageBox.Show("Vui lòng nhập mã phòng cần tìm kiếm!");
                return;
            }

            TimKiemTheoMaKH(maKHCanTim);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            //lay du lieu
            string currentSearchText = txtTimKiem.Text.Trim();

            //kiem tra rong
            if (string.IsNullOrEmpty(currentSearchText))
            {
                dgvDanhSachKH_Load();
            }
            else
            {
                TimKiemTheoMaKH(currentSearchText);
            }
        }

        private void Reset_KhachHang_data()
        {
            txtMaKH.Text = txtTenKH.Text = cbbGioiTinh.Text = txtSoDienThoai.Text = txtCanCuoc.Text = txtDiaChi.Text = cbbMaPhong.Text = txtTenPhong.Text = "";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Reset_KhachHang_data();
            DisableKhachHangControls();

        }
        private void XoaKhachHang(string maKH)
        {
            try
            {
                // truy van delete
                string sql = "DELETE FROM KhachHang WHERE MaKH = @maKH";
                object[] parameters = { maKH };
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(sql, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Đã xóa khách hàng thành công!");
                    dgvDanhSachKH_Load();
                    Reset_KhachHang_data();
                }
                else
                {
                    MessageBox.Show("Không thể xóa khách hàng. Vui lòng kiểm tra lại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maKHCanXoa = txtMaKH.Text.Trim();

            //kiem tra rong
            if (string.IsNullOrEmpty(maKHCanXoa))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
            //neu chọn yes thi xoa
                XoaKhachHang(maKHCanXoa);
            }
            else
            {
  
            }
        }
        int ChucNang = 0;
        private void btnThem_Click(object sender, EventArgs e)
        {
            ChucNang = 1;
            txtMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            cbbGioiTinh.Enabled = true;
            txtSoDienThoai.Enabled = true;
            txtCanCuoc.Enabled = true;
            txtDiaChi.Enabled = true;
            cbbMaPhong.Enabled = true;
            txtTenPhong.Enabled = false;

            btnLuu.Enabled = true;
            btnSua.Enabled = false; 
            btnXoa.Enabled = false; 

            Reset_KhachHang_data();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ChucNang = 2;
            txtMaKH.Enabled = false;
            txtTenKH.Enabled = true;
            cbbGioiTinh.Enabled = true;
            txtSoDienThoai.Enabled = true;
            txtCanCuoc.Enabled = true;
            txtDiaChi.Enabled = true;
            cbbMaPhong.Enabled = true;
            txtTenPhong.Enabled = false;

            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void KhachHangControl1_Load(object sender, EventArgs e)
        {
            dgvDanhSachKH_Load();
            LoadDataForComboBoxGioiTinh();
            LoadDataForComboBoxMaPhong();
            cbbMaPhong.SelectedIndexChanged += new EventHandler(cbbMaPhong_SelectedIndexChanged);

            DisableKhachHangControls();

            //Khong cho nhap chu
            txtSoDienThoai.KeyPress += new KeyPressEventHandler(txtSoDienThoai_KeyPress);
            txtCanCuoc.KeyPress += new KeyPressEventHandler(txtCanCuoc_KeyPress);
        }
        private void LoadDataForComboBoxGioiTinh()
        {
            List<string> gioiTinhList = new List<string> { "Nam", "Nữ" };
            cbbGioiTinh.DataSource = gioiTinhList;
        }

        private void LoadDataForComboBoxMaPhong()
        {
            // lay du lieu tu sql
            string sql = "SELECT MaPhong FROM Phong";
            DataTable dt = DataProvider.Instance.ExecuteQuery(sql);
            cbbMaPhong.DataSource = dt;
            cbbMaPhong.DisplayMember = "MaPhong";
            cbbMaPhong.ValueMember = "MaPhong";
        }

        private void dgvDanhSachKH_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvDanhSachKH.CurrentRow.Index;
            txtMaKH.Text = dgvDanhSachKH.Rows[i].Cells[0].Value.ToString().Trim();
            txtTenKH.Text = dgvDanhSachKH.Rows[i].Cells[1].Value.ToString().Trim();
            cbbGioiTinh.Text = dgvDanhSachKH.Rows[i].Cells[2].Value.ToString().Trim();
            txtSoDienThoai.Text = dgvDanhSachKH.Rows[i].Cells[3].Value.ToString().Trim();
            txtCanCuoc.Text = dgvDanhSachKH.Rows[i].Cells[4].Value.ToString().Trim();
            txtDiaChi.Text = dgvDanhSachKH.Rows[i].Cells[5].Value.ToString().Trim();
            cbbMaPhong.Text = dgvDanhSachKH.Rows[i].Cells[6].Value.ToString().Trim();
            txtTenPhong.Text = dgvDanhSachKH.Rows[i].Cells[7].Value.ToString().Trim();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void dgvDanhSachKH_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvDanhSachKH.CurrentRow.Index;
            txtMaKH.Text = dgvDanhSachKH.Rows[i].Cells[0].Value.ToString().Trim();
            txtTenKH.Text = dgvDanhSachKH.Rows[i].Cells[1].Value.ToString().Trim();
            cbbGioiTinh.Text = dgvDanhSachKH.Rows[i].Cells[2].Value.ToString().Trim();
            txtSoDienThoai.Text = dgvDanhSachKH.Rows[i].Cells[3].Value.ToString().Trim();
            txtCanCuoc.Text = dgvDanhSachKH.Rows[i].Cells[4].Value.ToString().Trim();
            txtDiaChi.Text = dgvDanhSachKH.Rows[i].Cells[5].Value.ToString().Trim();
            cbbMaPhong.Text = dgvDanhSachKH.Rows[i].Cells[6].Value.ToString().Trim();
            txtTenPhong.Text = dgvDanhSachKH.Rows[i].Cells[7].Value.ToString().Trim();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void cbbMaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMaPhong.SelectedItem != null)
            {
                string maPhong = cbbMaPhong.SelectedValue.ToString();
                LayTenPhongTuMaPhong(maPhong);
            }
        }
        private void LayTenPhongTuMaPhong(string maPhong)
        {
            string sql = "SELECT TenPhong FROM Phong WHERE MaPhong = @maPhong";
            DataTable dt = DataProvider.Instance.ExecuteQuery(sql, new object[] { maPhong });
            if (dt.Rows.Count > 0)
            {
                string tenPhong = dt.Rows[0]["TenPhong"].ToString();
                txtTenPhong.Text = tenPhong;
            }
            else
            {
                txtTenPhong.Text = "";
            }
        }
        private bool IsValidDataKhachHang()
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text) ||
                string.IsNullOrWhiteSpace(txtTenKH.Text) ||
                string.IsNullOrWhiteSpace(cbbGioiTinh.Text) ||
                string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ||
                string.IsNullOrWhiteSpace(txtCanCuoc.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(cbbMaPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return false;
            }

            // validate makh
            if (ChucNang == 1 && !IsMaKhachHangUnique(txtMaKH.Text.Trim()))
            {
                MessageBox.Show("Mã khách hàng đã tồn tại. Vui lòng chọn mã khác!");
                return false;
            }

            return true;
        }
        private bool IsMaKhachHangUnique(string maKH)
        {
            string sqlCheckDuplicate = "SELECT COUNT(*) FROM KhachHang WHERE MaKH = @maKH";
            int countDuplicate = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(sqlCheckDuplicate, new object[] { maKH }));
            return countDuplicate == 0;
        }
        private void CapNhatTenPhong()
        {
            if (cbbMaPhong.SelectedItem != null)
            {
                string maPhong = cbbMaPhong.SelectedValue.ToString();
                LayTenPhongTuMaPhong(maPhong);
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!IsValidDataKhachHang())
            {
                return;
            }

            try
            {
                string connectionString = "Data Source=DESKTOP-HR0MVSB\\SQLEXPRESS;Initial Catalog=quanlynhatro;Integrated Security=True";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();

                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.CommandType = CommandType.Text;

                        if (ChucNang == 1) // Thêm
                        {
                            sqlCmd.CommandText = "INSERT INTO KhachHang (MaKH, TenKH, GioiTinh, SoDienThoai, CanCuoc, DiaChi, MaPhong, TenPhong) VALUES (@maKH, @tenKH, @gioiTinh, @soDienThoai, @canCuoc, @diaChi, @maPhong, @tenPhong)";
                        }
                        else if (ChucNang == 2) // Sửa
                        {
                            sqlCmd.CommandText = "UPDATE KhachHang SET TenKH=@tenKH, GioiTinh=@gioiTinh, SoDienThoai=@soDienThoai, CanCuoc=@canCuoc, DiaChi=@diaChi, MaPhong=@maPhong, TenPhong=@tenPhong WHERE MaKH=@maKH";
                        }

                        sqlCmd.Parameters.AddWithValue("@maKH", txtMaKH.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@tenKH", txtTenKH.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@gioiTinh", cbbGioiTinh.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@soDienThoai", txtSoDienThoai.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@canCuoc", txtCanCuoc.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@maPhong", cbbMaPhong.SelectedValue.ToString().Trim());
                        sqlCmd.Parameters.AddWithValue("@tenPhong", txtTenPhong.Text.Trim());

                        sqlCmd.Connection = sqlCon;

                        int kq = sqlCmd.ExecuteNonQuery();

                        if (kq > 0)
                        {
                            if (ChucNang == 1)
                            {
                                MessageBox.Show("Thêm khách hàng thành công!");
                            }
                            else if (ChucNang == 2)
                            {
                                MessageBox.Show("Cập nhật khách hàng thành công!");
                            }

                            dgvDanhSachKH_Load();
                            Reset_KhachHang_data();
                            DisableKhachHangControls();
                            LayTenPhongTuMaPhong(cbbMaPhong.SelectedValue.ToString());
                        }
                        else
                        {
                            if (ChucNang == 1)
                            {
                                MessageBox.Show("Thêm khách hàng thất bại!");
                            }
                            else if (ChucNang == 2)
                            {
                                MessageBox.Show("Cập nhật khách hàng thất bại!");
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

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            //chi cho nhap so
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCanCuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
