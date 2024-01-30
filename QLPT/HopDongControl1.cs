using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPT
{
    public partial class HopDongControl1 : UserControl
    {
        public HopDongControl1()
        {
            InitializeComponent();
        }
        Boolean chucnang = true;
        private void HopDongControl1_Load(object sender, EventArgs e)
        {
            dtgHopDong_load();
            DataProvider.Instance.FillCombo("select *from KhachHang", cbbMaKH, "MaKH", "TenKH");
            DataProvider.Instance.FillCombo("select * from Phong", cbbMaPhong, "MaPhong", "TenPhong");
            txtGiaPhong.Enabled = false;
            Reset_Data();
            GetHeaderText();
        }

        private void dtgHopDong_load()
        {
            string sql = "select a.MaHopDong,a.MaKH,a.TenKH,a.MaPhong,a.TenPhong,b.GiaPhong, a.TienCoc,a.NgayThue,a.NgayTra\r\nfrom HopDongTro as a, Phong as b\r\nwhere a.MaPhong = b.MaPhong";
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.ExecuteQuery(sql);
            dtgSDTHopDong.DataSource = dt;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtMaHD.Enabled = true;
            cbbMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            cbbMaPhong.Enabled = true;
            txtTenPhong.Enabled = true;
            txtGiaPhong.Enabled = true;
            txtTienCoc.Enabled = true;
            dtpNgayThue.Enabled = true;
            dtpNgayTra.Enabled = true;
            chucnang = true;
        }
        private void Them()
        {
            try
            {
                if (txtMaHD.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập Mã Hợp Đồng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaHD.Focus();
                    return;
                }
                if (cbbMaKH.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn Mã Khách Hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaHD.Focus();
                    return;
                }
                if (txtTenKH.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập Tên Khách Hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaHD.Focus();
                    return;
                }
                if (cbbMaPhong.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn Mã Phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaHD.Focus();
                    return;
                }
                if (txtTenPhong.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập Tên Phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaHD.Focus();
                    return;
                }
                if (txtTienCoc.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập Tiền Cọc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaHD.Focus();
                    return;
                }
                if (dtpNgayThue.Value == dtpNgayTra.Value)
                {
                    MessageBox.Show("Ngày Trả không hợp lệ rồi !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpNgayTra.Focus();
                    return;
                }
                string sql = "insert into HopDongTro(MaHopDong,MaKH,TenKH,MaPhong,TenPhong,TienCoc,NgayThue,NgayTra) " +
               "values('" + txtMaHD.Text.ToString().Trim() + "','" + cbbMaKH.Text.ToString().Trim() + "'," +
               "'" + txtTenKH.Text.ToString().Trim() + "','" + cbbMaPhong.Text.ToString().Trim() + "'," +
               "'" + txtTenPhong.Text.ToString().Trim() + "'," + "'" + txtTienCoc.Text.ToString().Trim() + "'," +
               "'" + dtpNgayThue.Value.ToString("yyyy-MM-dd") + "','" + dtpNgayTra.Value.ToString("yyyy-MM-dd") + "')";
                DataProvider.Instance.ExecuteNonQuery(sql);
                MessageBox.Show(" Đã Thêm thành công !");
                Reset_Data();
                dtgHopDong_load();
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại Mã Khách Hàng với Mã Phòng lại xem", "Sai cú pháp rồi nhé !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset_Data();
            }
        }

        private void Reset_Data()
        {
            txtMaHD.Text = "";
            txtGiaPhong.Text = txtTenKH.Text = txtTenPhong.Text = "";
            txtTienCoc.Text = txtTK.Text = cbbMaKH.Text = cbbMaPhong.Text = "";
            dtpNgayThue.Value = dtpNgayTra.Value = DateTime.Now;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            // dong bang het
            txtMaHD.Enabled = false;
            cbbMaKH.Enabled = false;
            txtTenKH.Enabled = false;
            cbbMaPhong.Enabled = false;
            txtTenPhong.Enabled = false;
            txtTienCoc.Enabled = false;
            dtpNgayThue.Enabled = false;
            dtpNgayTra.Enabled = false;
            dtgHopDong_load();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Reset_Data();
        }

        private void cbbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMaKH.Text == "")
            {
                txtTenKH.Text = "";
            }
            else
            {
                txtTenKH.Text = cbbMaKH.SelectedValue.ToString().Trim();
                string MaKH = cbbMaKH.Text;
                string sql = $"select a.MaHopDong,a.MaKH,a.TenKH,a.MaPhong,a.TenPhong,b.GiaPhong, a.TienCoc,a.NgayThue,a.NgayTra " +
                    $"from HopDongTro as a, Phong as b where a.MaPhong = b.MaPhong and a.MaKH ='{MaKH}'";
                DataTable dt = new DataTable();
                dt = DataProvider.Instance.ExecuteQuery(sql);
                dtgSDTHopDong.DataSource = dt;

            }
        }

        private void cbbMaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMaPhong.Text == "")
            {
                txtTenPhong.Text = "";
            }
            else
            {
                txtTenPhong.Text = cbbMaPhong.SelectedValue.ToString().Trim();
                string MaPhong = cbbMaPhong.Text;
                string sql = $"select a.MaHopDong,a.MaKH,a.TenKH,a.MaPhong,a.TenPhong,b.GiaPhong, a.TienCoc,a.NgayThue,a.NgayTra " +
                                   $"from HopDongTro as a, Phong as b where a.MaPhong = b.MaPhong and a.MaPhong ='{MaPhong}'";
                DataTable dt = new DataTable();
                dt = DataProvider.Instance.ExecuteQuery(sql);
                dtgSDTHopDong.DataSource = dt;

            }
        }

        private void dtgSDTHopDong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgSDTHopDong.CurrentRow.Index;
            txtMaHD.Text = dtgSDTHopDong.Rows[i].Cells[0].Value.ToString().Trim();
            cbbMaKH.Text = dtgSDTHopDong.Rows[i].Cells[1].Value.ToString().Trim();
            txtTenKH.Text = dtgSDTHopDong.Rows[i].Cells[2].Value.ToString().Trim();
            cbbMaPhong.Text = dtgSDTHopDong.Rows[i].Cells[3].Value.ToString().Trim();
            txtTenPhong.Text = dtgSDTHopDong.Rows[i].Cells[4].Value.ToString().Trim();
            txtGiaPhong.Text = dtgSDTHopDong.Rows[i].Cells[5].Value.ToString().Trim();
            txtTienCoc.Text = dtgSDTHopDong.Rows[i].Cells[6].Value.ToString().Trim();
            dtpNgayThue.Value = (DateTime)dtgSDTHopDong.Rows[i].Cells[7].Value;
            dtpNgayTra.Value = (DateTime)dtgSDTHopDong.Rows[i].Cells[8].Value;

            btnSua.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
        }

        private void dtgSDTHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgSDTHopDong.CurrentRow.Index;
            txtMaHD.Text = dtgSDTHopDong.Rows[i].Cells[0].Value.ToString().Trim();
            cbbMaKH.Text = dtgSDTHopDong.Rows[i].Cells[1].Value.ToString().Trim();
            txtTenKH.Text = dtgSDTHopDong.Rows[i].Cells[2].Value.ToString().Trim();
            cbbMaPhong.Text = dtgSDTHopDong.Rows[i].Cells[3].Value.ToString().Trim();
            txtTenPhong.Text = dtgSDTHopDong.Rows[i].Cells[4].Value.ToString().Trim();
            txtGiaPhong.Text = dtgSDTHopDong.Rows[i].Cells[5].Value.ToString().Trim();
            txtTienCoc.Text = dtgSDTHopDong.Rows[i].Cells[6].Value.ToString().Trim();
            dtpNgayThue.Value = (DateTime)dtgSDTHopDong.Rows[i].Cells[7].Value;
            dtpNgayTra.Value = (DateTime)dtgSDTHopDong.Rows[i].Cells[8].Value;

            btnSua.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string MaHD = txtTK.Text.Trim();
            if (txtTK.Text == "")
            {
                MessageBox.Show("Bạn phải nhập Mã Hợp Đồng");
                txtTK.Focus();
                Reset_Data();
                return;
            }
            string sql = $"select a.MaHopDong,a.MaKH,a.TenKH,a.MaPhong,a.TenPhong,b.GiaPhong, a.TienCoc,a.NgayThue,a.NgayTra " +
                   $"from HopDongTro as a, Phong as b where a.MaPhong = b.MaPhong and a.MaHopDong ='{MaHD}'";
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.ExecuteQuery(sql);
            foreach (DataRow item in dt.Rows)
            {
                txtMaHD.Text = item["MaHopDong"].ToString();
                cbbMaKH.Text = item["MaKH"].ToString();
                txtTenKH.Text = item["TenKH"].ToString();
                cbbMaPhong.Text = item["MaPhong"].ToString();
                txtTenPhong.Text = item["TenPhong"].ToString();
                txtGiaPhong.Text = item["GiaPhong"].ToString();
                txtTienCoc.Text = item["TienCoc"].ToString();
                dtpNgayThue.Value = (DateTime)item["NgayThue"];
                dtpNgayTra.Value = (DateTime)item["NgayTra"];
            }
            dtgSDTHopDong.DataSource = dt;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Mã Hợp Đồng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHD.Focus();
                return;
            }
            string maHD = txtMaHD.Text;
            string sql = $"Delete HopDongTro where MaHopDong = N'{maHD}'";
            try
            {
                DataProvider.Instance.ExecuteNonQuery(sql);
                MessageBox.Show("Đã xóa thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Chưa xóa được");
            }
            Reset_Data();
            dtgHopDong_load();
        }

        private void cbbMaKH_SelectedValueChanged(object sender, EventArgs e)
        {
            txtGiaPhong.Text = txtTenPhong.Text = "";
            txtTienCoc.Text = txtTK.Text = cbbMaPhong.Text = "";
            dtpNgayThue.Value = dtpNgayTra.Value = DateTime.Now;
        }

        private void cbbMaPhong_SelectedValueChanged(object sender, EventArgs e)
        {
            txtGiaPhong.Text = /*txtTenKH.Text = cbbMaKH.Text =*/ "";
            txtTienCoc.Text = txtTK.Text = "";
            dtpNgayThue.Value = dtpNgayTra.Value = DateTime.Now;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtMaHD.Enabled = true;
            cbbMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            cbbMaPhong.Enabled = true;
            txtTenPhong.Enabled = true;
            txtGiaPhong.Enabled = true;
            txtTienCoc.Enabled = true;
            dtpNgayThue.Enabled = true;
            dtpNgayTra.Enabled = true;
            txtMaHD.Enabled = false;
            chucnang = false;
        }

        private void Sua()
        {
            try
            {
                if (txtMaHD.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập Mã Hợp Đồng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaHD.Focus();
                    return;
                }
                if (cbbMaKH.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn Mã Khách Hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaHD.Focus();
                    return;
                }
                if (txtTenKH.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập Tên Khách Hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaHD.Focus();
                    return;
                }
                if (cbbMaPhong.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn Mã Phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaHD.Focus();
                    return;
                }
                if (txtTenPhong.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập Tên Phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaHD.Focus();
                    return;
                }
                if (txtTienCoc.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập Tiền Cọc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaHD.Focus();
                    return;
                }
                if (dtpNgayThue.Value == dtpNgayTra.Value)
                {
                    MessageBox.Show("Ngày Trả không hợp lệ rồi !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpNgayTra.Focus();
                    return;
                }
                string MaHD = txtMaHD.Text;
                string sql = "update HopDongTro set TenKH = '" + txtTenKH.Text.ToString() + "'," +
                "TienCoc ='" + int.Parse(txtTienCoc.Text) + "'," +
                    "NgayThue = '" + dtpNgayThue.Value.ToString("yyyy-MM-dd") + "'," +
                    " NgayTra = '" + dtpNgayTra.Value.ToString("yyyy-MM-dd") + "'" +
                    $"where MaHopDong = '{MaHD}'";
                DataProvider.Instance.ExecuteNonQuery(sql);
                Reset_Data();
                dtgHopDong_load();
                MessageBox.Show("Đã Sửa thành công");
            }
            catch
            {
                MessageBox.Show("Chưa Sửa được nhé !! ");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (chucnang == true)
                {
                    Them();
                }
                else
                {
                    Sua();
                }
                Reset_Data();
            }
            catch
            {
                MessageBox.Show("Errol roi  nhé !! ");
            }
        }

        private void txtTienCoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }
        void GetHeaderText()
        {
            dtgSDTHopDong.Columns[0].HeaderText = "Mã Hợp Đồng";
            dtgSDTHopDong.Columns[1].HeaderText = "Mã Khách Hàng";
            dtgSDTHopDong.Columns[2].HeaderText = "Tên Khách Hàng";
            dtgSDTHopDong.Columns[3].HeaderText = "Mã Phòng";
            dtgSDTHopDong.Columns[4].HeaderText = "Tên phòng";
            dtgSDTHopDong.Columns[5].HeaderText = "Giá Phòng";
            dtgSDTHopDong.Columns[6].HeaderText = "Tiền Cọc";
            dtgSDTHopDong.Columns[7].HeaderText = "Ngày Thuê";
            dtgSDTHopDong.Columns[8].HeaderText = "Ngày Trả";

        }
    }
}
