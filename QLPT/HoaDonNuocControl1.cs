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
    public partial class HoaDonNuocControl1 : UserControl
    {
        HoaDonNuocCommand hoaDonNuocCommand = new HoaDonNuocCommand();
        PhongCommand phongCommand = new PhongCommand();

        public HoaDonNuocControl1()
        {
            InitializeComponent();
            Load();
        }
        Boolean chucnang = true;
        new void Load()
        {
            GetListHoaDonNuoc();
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
            txtMaHDNuoc.Text = "";
            cbbMaPhong.Text = "";
            txtTenPhong.Text = "";
            dtpNgayTinhTien.Value = DateTime.Now;
            txtChiSoNuocCu.Text = "";
            txtChiSoNuocMoi.Text = "";
            txtChiSoSD.Text = "";
            txtGiaNuoc.Text = "";
            txtTienNuoc.Text = "";
            txtTK.Text = "";

            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnTinhTien.Enabled = false;

            txtMaHDNuoc.Enabled = false;
            cbbMaPhong.Enabled = false;
            txtTenPhong.Enabled = false;
            dtpNgayTinhTien.Enabled = false;
            txtChiSoNuocCu.Enabled = false;
            txtChiSoNuocMoi.Enabled = false;
            txtChiSoSD.Enabled = false;
            txtGiaNuoc.Enabled = false;
            txtTienNuoc.Enabled = false;

        }

        void GetListHoaDonNuoc()
        {
            dtgvHoaDonNuoc.DataSource = hoaDonNuocCommand.GetListHoaDonNuoc();
        }

        private void dtgvHoaDonNuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvHoaDonNuoc.CurrentRow.Index;
            txtMaHDNuoc.Text = dtgvHoaDonNuoc.Rows[i].Cells[0].Value.ToString().Trim();
            cbbMaPhong.Text = dtgvHoaDonNuoc.Rows[i].Cells[1].Value.ToString().Trim();
            txtTenPhong.Text = dtgvHoaDonNuoc.Rows[i].Cells[2].Value.ToString().Trim();
            dtpNgayTinhTien.Value = (DateTime)dtgvHoaDonNuoc.Rows[i].Cells[3].Value;
            txtChiSoNuocCu.Text = dtgvHoaDonNuoc.Rows[i].Cells[4].Value.ToString().Trim();
            txtChiSoNuocMoi.Text = dtgvHoaDonNuoc.Rows[i].Cells[5].Value.ToString().Trim();
            txtChiSoSD.Text = dtgvHoaDonNuoc.Rows[i].Cells[6].Value.ToString().Trim();
            txtGiaNuoc.Text = dtgvHoaDonNuoc.Rows[i].Cells[7].Value.ToString().Trim();
            txtTienNuoc.Text = dtgvHoaDonNuoc.Rows[i].Cells[8].Value.ToString().Trim();

            EnableItems();
        }

        void GetHeaderText()
        {
            dtgvHoaDonNuoc.Columns[0].HeaderText = "Mã hóa đơn";
            dtgvHoaDonNuoc.Columns[1].HeaderText = "Mã phòng";
            dtgvHoaDonNuoc.Columns[2].HeaderText = "Tên phòng";
            dtgvHoaDonNuoc.Columns[3].HeaderText = "Ngày tính tiền";
            dtgvHoaDonNuoc.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgvHoaDonNuoc.Columns[4].HeaderText = "Chỉ số nước cũ";
            dtgvHoaDonNuoc.Columns[5].HeaderText = "Chỉ số nước mới";
            dtgvHoaDonNuoc.Columns[6].HeaderText = "Chỉ số nước sử dụng";
            dtgvHoaDonNuoc.Columns[7].HeaderText = "Giá nước";
            dtgvHoaDonNuoc.Columns[8].HeaderText = "Tổng nước";

        }

        private void HoaDonNuocControl1_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaHDNuoc.Enabled = true;
            cbbMaPhong.Enabled = true;
            txtTenPhong.Enabled = true;
            dtpNgayTinhTien.Enabled = true;
            txtChiSoNuocCu.Enabled = true;
            txtChiSoNuocMoi.Enabled = true;
            txtChiSoSD.Enabled = true;
            txtGiaNuoc.Enabled = true;
            txtTienNuoc.Enabled = true;
            chucnang = true; 
            btnLuu.Enabled = true;
            btnTinhTien.Enabled = true;
        }
        private void Them()
        {
            HoaDonNuoc hoaDonNuocDTO = new HoaDonNuoc();
            hoaDonNuocDTO.maHoaDonNuoc = txtMaHDNuoc.Text;
            hoaDonNuocDTO.maPhong = cbbMaPhong.Text;
            hoaDonNuocDTO.tenPhong = txtTenPhong.Text;
            hoaDonNuocDTO.ngayTinhTien = dtpNgayTinhTien.Value;
            hoaDonNuocDTO.chiSoNuocCu = Convert.ToInt32(txtChiSoNuocCu.Text);
            hoaDonNuocDTO.chiSoNuocMoi = Convert.ToInt32(txtChiSoNuocMoi.Text);
            hoaDonNuocDTO.chiSoNuocSuDung = Convert.ToInt32(txtChiSoSD.Text);
            hoaDonNuocDTO.giaNuoc = Convert.ToInt32(txtGiaNuoc.Text);
            hoaDonNuocDTO.tienNuoc = Convert.ToInt32(txtTienNuoc.Text);

            if (string.IsNullOrEmpty(txtMaHDNuoc.Text))
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

            try
            {
                if (hoaDonNuocCommand.ThemHoaDonNuoc(hoaDonNuocDTO))
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaHDNuoc.Enabled = true;
            cbbMaPhong.Enabled = true;
            txtTenPhong.Enabled = true;
            dtpNgayTinhTien.Enabled = true;
            txtChiSoNuocCu.Enabled = true;
            txtChiSoNuocMoi.Enabled = true;
            txtChiSoSD.Enabled = true;
            txtGiaNuoc.Enabled = true;
            txtTienNuoc.Enabled = true;
            chucnang = false;
            btnLuu.Enabled = true;
            btnTinhTien.Enabled = true;
        }
        private void Sua()
        {
            HoaDonNuoc hoaDonNuocDTO = new HoaDonNuoc();
            hoaDonNuocDTO.maHoaDonNuoc = txtMaHDNuoc.Text;
            hoaDonNuocDTO.maPhong = cbbMaPhong.Text;
            hoaDonNuocDTO.tenPhong = txtTenPhong.Text;
            hoaDonNuocDTO.ngayTinhTien = dtpNgayTinhTien.Value;
            hoaDonNuocDTO.chiSoNuocCu = Convert.ToInt32(txtChiSoNuocCu.Text);
            hoaDonNuocDTO.chiSoNuocMoi = Convert.ToInt32(txtChiSoNuocMoi.Text);
            hoaDonNuocDTO.chiSoNuocSuDung = Convert.ToInt32(txtChiSoSD.Text);
            hoaDonNuocDTO.giaNuoc = Convert.ToInt32(txtGiaNuoc.Text);
            hoaDonNuocDTO.tienNuoc = Convert.ToInt32(txtTienNuoc.Text);

            try
            {
                if (hoaDonNuocCommand.SuaHoaDonNuoc(hoaDonNuocDTO))
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
                if (hoaDonNuocCommand.XoaHoaDonNuoc(txtMaHDNuoc.Text))
                {
                    MessageBox.Show("Xóa hóa đơn thành công");
                    Load();
                }

            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Load();
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            dtgvHoaDonNuoc.DataSource = hoaDonNuocCommand.TimTheoHoaDonNuoc(txtTK.Text);
        }

        private void dtgvHoaDonNuoc_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvHoaDonNuoc.CurrentRow.Index;
            txtMaHDNuoc.Text = dtgvHoaDonNuoc.Rows[i].Cells[0].Value.ToString().Trim();
            cbbMaPhong.Text = dtgvHoaDonNuoc.Rows[i].Cells[1].Value.ToString().Trim();
            txtTenPhong.Text = dtgvHoaDonNuoc.Rows[i].Cells[2].Value.ToString().Trim();
            dtpNgayTinhTien.Value = (DateTime)dtgvHoaDonNuoc.Rows[i].Cells[3].Value;
            txtChiSoNuocCu.Text = dtgvHoaDonNuoc.Rows[i].Cells[4].Value.ToString().Trim();
            txtChiSoNuocMoi.Text = dtgvHoaDonNuoc.Rows[i].Cells[5].Value.ToString().Trim();
            txtChiSoSD.Text = dtgvHoaDonNuoc.Rows[i].Cells[6].Value.ToString().Trim();
            txtGiaNuoc.Text = dtgvHoaDonNuoc.Rows[i].Cells[7].Value.ToString().Trim();
            txtTienNuoc.Text = dtgvHoaDonNuoc.Rows[i].Cells[8].Value.ToString().Trim();

            EnableItems();
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
                MessageBox.Show("Lỗi ! ");
            }
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            try
            {
                int chiSoNuocSuDung = Convert.ToInt32(txtChiSoSD.Text);
                int giaNuoc = Convert.ToInt32(txtGiaNuoc.Text);

                // Tính tiền và hiển thị kết quả
                int tienNuoc = chiSoNuocSuDung * giaNuoc;
                txtTienNuoc.Text = tienNuoc.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi tính tiền nước! Vui lòng kiểm tra lại các giá trị.");
            }
        }

        private void txtChiSoNuocCu_TextChanged(object sender, EventArgs e)
        {
            TinhChisoSD();
        }

        private void txtChiSoNuocMoi_TextChanged(object sender, EventArgs e)
        {
            TinhChisoSD();
        }
        private void TinhChisoSD()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtChiSoNuocCu.Text) && !string.IsNullOrEmpty(txtChiSoNuocMoi.Text))
                {
                    int chiSoCu = Convert.ToInt32(txtChiSoNuocCu.Text);
                    int chiSoMoi = Convert.ToInt32(txtChiSoNuocMoi.Text);

                    // Tính chỉ số sử dụng và hiển thị kết quả
                    int chiSoSD = chiSoMoi - chiSoCu;
                    txtChiSoSD.Text = chiSoSD.ToString();
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

