using QLPT.DTO;
using QLPT.SQLCommand;
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
    public partial class HoaDonDienControl1 : UserControl
    {
        HoaDonDienCommand hoaDonDienCommand = new HoaDonDienCommand();
        PhongCommand phongCommand = new PhongCommand();
        public HoaDonDienControl1()
        {
            InitializeComponent();
            Load();
        }
        Boolean chucnang = true;
        private void HoaDonDienControl1_Load(object sender, EventArgs e)
        {
           
        }

        new void Load()
        {
            GetListHoaDonDien();
            GetHeaderText();
            DisableItems();
            ClearItems();
        }

        void DisableItems()
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        void EnableItems()
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        void ClearItems()
        {
            txtMaHDDien.Text = "";
            cbbMaPhong.Text = "";
            txtTenPhong.Text = "";
            dtpNgayTinhTien.Value = DateTime.Now;
            txtSoDienCu.Text = "";
            txtSoDienMoi.Text = "";
            txtSoSD.Text = "";
            txtGiaDien.Text = "";
            txtTienDien.Text = "";
            txtTimKiem.Text = "";

            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtTinhTien.Enabled = false;

            txtMaHDDien.Enabled = false;
            cbbMaPhong.Enabled = false;
            txtTenPhong.Enabled = false;
            dtpNgayTinhTien.Enabled = false;
            txtSoDienCu.Enabled = false;
            txtSoDienMoi.Enabled = false;
            txtSoSD.Enabled = false;
            txtGiaDien.Enabled = false;
            txtTienDien.Enabled = false;
        }

        void GetListHoaDonDien()
        {
            dtgvHoaDonDien.DataSource = hoaDonDienCommand.GetListHoaDonDien();
        }

        void GetHeaderText()
        {
            dtgvHoaDonDien.Columns[0].HeaderText = "Mã hóa đơn";
            dtgvHoaDonDien.Columns[1].HeaderText = "Mã phòng";
            dtgvHoaDonDien.Columns[2].HeaderText = "Tên phòng";
            dtgvHoaDonDien.Columns[3].HeaderText = "Ngày tính tiền";
            dtgvHoaDonDien.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgvHoaDonDien.Columns[4].HeaderText = "Chỉ số điện cũ";
            dtgvHoaDonDien.Columns[5].HeaderText = "Chỉ số điện mới";
            dtgvHoaDonDien.Columns[6].HeaderText = "Chỉ số điện sử dụng";
            dtgvHoaDonDien.Columns[7].HeaderText = "Giá điện";
            dtgvHoaDonDien.Columns[8].HeaderText = "Tổng tiền";

        }

        private void dtgvHoaDonDien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvHoaDonDien.CurrentRow.Index;
            txtMaHDDien.Text = dtgvHoaDonDien.Rows[i].Cells[0].Value.ToString().Trim();
            cbbMaPhong.Text = dtgvHoaDonDien.Rows[i].Cells[1].Value.ToString().Trim();
            txtTenPhong.Text = dtgvHoaDonDien.Rows[i].Cells[2].Value.ToString().Trim();
            dtpNgayTinhTien.Value = (DateTime)dtgvHoaDonDien.Rows[i].Cells[3].Value;
            txtSoDienCu.Text = dtgvHoaDonDien.Rows[i].Cells[4].Value.ToString().Trim();
            txtSoDienMoi.Text = dtgvHoaDonDien.Rows[i].Cells[5].Value.ToString().Trim();
            txtSoSD.Text = dtgvHoaDonDien.Rows[i].Cells[6].Value.ToString().Trim();
            txtGiaDien.Text = dtgvHoaDonDien.Rows[i].Cells[7].Value.ToString().Trim();
            txtTienDien.Text = dtgvHoaDonDien.Rows[i].Cells[8].Value.ToString().Trim();

            EnableItems();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaHDDien.Enabled = true;
            cbbMaPhong.Enabled = true;
            txtTenPhong.Enabled = true;
            dtpNgayTinhTien.Enabled = true;
            txtSoDienCu.Enabled = true;
            txtSoDienMoi.Enabled = true;
            txtSoSD.Enabled = true;
            txtGiaDien.Enabled = true;
            txtTienDien.Enabled = true;
            chucnang = true; 
            btnLuu.Enabled = true;
            txtTinhTien.Enabled = true;
        }
        private void Them()
        {
            HoaDonDienDTO hoaDonDienDTO = new HoaDonDienDTO();
            hoaDonDienDTO.maHoaDonDien = txtMaHDDien.Text;
            hoaDonDienDTO.maPhong = cbbMaPhong.Text;
            hoaDonDienDTO.tenPhong = txtTenPhong.Text;
            hoaDonDienDTO.ngayTinhTien = dtpNgayTinhTien.Value;
            hoaDonDienDTO.chiSoDienCu = Convert.ToInt32(txtSoDienCu.Text);
            hoaDonDienDTO.chiSoDienMoi = Convert.ToInt32(txtSoDienMoi.Text);
            hoaDonDienDTO.chiSoDienSuDung = Convert.ToInt32(txtSoSD.Text);
            hoaDonDienDTO.giaDien = Convert.ToInt32(txtGiaDien.Text);
            hoaDonDienDTO.tienDien = Convert.ToInt32(txtTienDien.Text);

            if (string.IsNullOrEmpty(txtMaHDDien.Text))
            {
                MessageBox.Show("Mã hóa đơn không được để trống");
                return;
            }

            if (string.IsNullOrEmpty(cbbMaPhong.Text))
            {
                MessageBox.Show("Mã phòng không được để trống");
                return;
            }

            if (dtpNgayTinhTien.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày tính tiền không hợp lệ");
                return;
            }

            if (string.IsNullOrEmpty(txtSoDienCu.Text))
            {
                MessageBox.Show("Số điện cũ không hợp lệ");
                return;
            }

            if (string.IsNullOrEmpty(txtSoDienMoi.Text))
            {
                MessageBox.Show("Số điện mới không hợp lệ");
                return;
            }

            if (txtSoSD.Text == "")
            {
                MessageBox.Show("Số điện sử dụng không hợp lệ");
                return;
            }

            try
            {
                if (hoaDonDienCommand.ThemHoaDonDien(hoaDonDienDTO))
                {
                    MessageBox.Show("Thêm hóa đơn thành công");
                    Load();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Mã hóa đơn đã tồn tại");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Load();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaHDDien.Enabled = true;
            cbbMaPhong.Enabled = true;
            txtTenPhong.Enabled = true;
            dtpNgayTinhTien.Enabled = true;
            txtSoDienCu.Enabled = true;
            txtSoDienMoi.Enabled = true;
            txtSoSD.Enabled = true;
            txtGiaDien.Enabled = true;
            txtTienDien.Enabled = true;
            chucnang = false;
            btnLuu.Enabled = true;
            txtTinhTien.Enabled = true;
        }
        private void Sua()
        {
            HoaDonDienDTO hoaDonDienDTO = new HoaDonDienDTO();
            hoaDonDienDTO.maHoaDonDien = txtMaHDDien.Text;
            hoaDonDienDTO.maPhong = cbbMaPhong.Text;
            hoaDonDienDTO.tenPhong = txtTenPhong.Text;
            hoaDonDienDTO.ngayTinhTien = dtpNgayTinhTien.Value;
            hoaDonDienDTO.chiSoDienCu = Convert.ToInt32(txtSoDienCu.Text);
            hoaDonDienDTO.chiSoDienMoi = Convert.ToInt32(txtSoDienMoi.Text);
            hoaDonDienDTO.chiSoDienSuDung = Convert.ToInt32(txtSoSD.Text);
            hoaDonDienDTO.giaDien = Convert.ToInt32(txtGiaDien.Text);
            hoaDonDienDTO.tienDien = Convert.ToInt32(txtTienDien.Text);

            try
            {
                if (hoaDonDienCommand.SuaHoaDonDien(hoaDonDienDTO))
                {
                    MessageBox.Show("Sửa hóa đơn thành công");
                    Load();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("lỗi");
            }
        }    

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (hoaDonDienCommand.XoaHoaDonDien(txtMaHDDien.Text))
                {
                    MessageBox.Show("Xóa hóa đơn thành công");
                    Load();
                }

            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dtgvHoaDonDien.DataSource = hoaDonDienCommand.TimTheoMaHoaDonDien(txtTimKiem.Text);
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
                ClearItems();
            }
            catch
            {
                MessageBox.Show("Lỗi!");
            }
        }

        private void txtTinhTien_Click(object sender, EventArgs e)
        {
            try
            {
                int chiSoDienSuDung = Convert.ToInt32(txtSoSD.Text);
                int giaNuoc = Convert.ToInt32(txtGiaDien.Text);

                // Tính tiền và hiển thị kết quả
                int tienNuoc = chiSoDienSuDung * giaNuoc;
                txtTienDien.Text = tienNuoc.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi tính tiền nước! Vui lòng kiểm tra lại các giá trị.");
            }
        }

        private void txtSoDienCu_TextChanged(object sender, EventArgs e)
        {
            TinhChisoSD();
        }

        private void txtSoDienMoi_TextChanged(object sender, EventArgs e)
        {
            TinhChisoSD();
        }
        private void TinhChisoSD()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSoDienCu.Text) && !string.IsNullOrEmpty(txtSoDienMoi.Text))
                {
                    int chiSoCu = Convert.ToInt32(txtSoDienCu.Text);
                    int chiSoMoi = Convert.ToInt32(txtSoDienMoi.Text);

                    // Tính chỉ số sử dụng và hiển thị kết quả
                    int chiSoSD = chiSoMoi - chiSoCu;
                    txtSoSD.Text = chiSoSD.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi tính chỉ số sử dụng! Vui lòng kiểm tra lại các giá trị.");
            }
        }
        void LoadComboBoxPhong()
        {
            cbbMaPhong.DataSource = phongCommand.GetListPhong();
            cbbMaPhong.DisplayMember = "MaPhong";
        }
        private void cbbMaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = null;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;
            PhongDTO phong = cb.SelectedItem as PhongDTO;
            id = phong.maPhong;

            List<PhongDTO> listP = phongCommand.SearchByID(id);
            foreach (var item in listP)
            {
                txtTenPhong.Text = item.tenPhong;
            }
        }
    }
}
