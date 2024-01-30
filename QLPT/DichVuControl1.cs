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
    public partial class DichVuControl1 : UserControl
    {
        public DichVuControl1()
        {
            InitializeComponent();
        }

        private void DichVuControl1_Load(object sender, EventArgs e)
        {
            dtgDichVu_load();
        }
        private void dtgDichVu_load()
        {
            string sql = "select* from DichVu";
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.ExecuteQuery(sql);
            dtgDichVu.DataSource = dt;
            txtMaDV.Enabled = false;
            txtGiaDV.Enabled = false;
            txtTenDV.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;

            GetHeaderText();
        }

        Boolean chucnang = false;

        private void Them()
        {
            if (txtMaDV.Text == "")
            {
                txtMaDV.Focus();
                MessageBox.Show("Bạn chưa nhập Mã Dịch Vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenDV.Text == "")
            {
                txtTenDV.Focus();
                MessageBox.Show("Bạn chưa nhập tên Dịch Vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtGiaDV.Text == "")
            {
                txtGiaDV.Focus();
                MessageBox.Show("Bạn chưa nhập giá dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string sql = "insert into DichVu(MaDV,TenDV,GiaDV) values ('" + txtMaDV.Text.ToString().Trim() + "'" +
                   ",'" + txtTenDV.Text.ToString().Trim() + "','" + txtGiaDV.Text.Trim() + "')";
                DataProvider.Instance.ExecuteNonQuery(sql);
                MessageBox.Show("Đã thêm thành công");
                Reset_data();
                dtgDichVu_load();
            }
            catch
            {
                MessageBox.Show("Mã Dịch Vụ bị trùng rồi !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaDV.Enabled = true;
            txtGiaDV.Enabled = true;
            txtTenDV.Enabled = true;
            chucnang = true;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            txtMaDV.Focus();
        }
        private void Reset_data()
        {
            txtTenDV.Text = txtMaDV.Text = txtGiaDV.Text = txtTK.Text = "";

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Reset_data();
            dtgDichVu_load();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaDV.Text == "")
            {
                txtMaDV.Focus();
                MessageBox.Show("Bạn chưa nhập Mã Dịch Vụ để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenDV.Text == "")
            {
                txtTenDV.Focus();
                MessageBox.Show("Bạn chưa nhập tên Dịch Vụ để xóa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtGiaDV.Text == "")
            {
                txtGiaDV.Focus();
                MessageBox.Show("Bạn chưa nhập giá Dịch vụ để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string maDV = txtMaDV.Text;
            string sql = $"Delete DichVu where MaDV = N'{maDV}'";
            try
            {
                DataProvider.Instance.ExecuteNonQuery(sql);
                MessageBox.Show("Đã xóa thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Chưa xóa được !!");
            }
            dtgDichVu_load();
        }

        private void dtgDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgDichVu.CurrentRow.Index;
            txtMaDV.Text = dtgDichVu.Rows[i].Cells[0].Value.ToString().Trim();
            txtTenDV.Text = dtgDichVu.Rows[i].Cells[1].Value.ToString().Trim();
            txtGiaDV.Text = dtgDichVu.Rows[i].Cells[2].Value.ToString().Trim();
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = false;
        }

        private void dtgDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgDichVu.CurrentRow.Index;
            txtMaDV.Text = dtgDichVu.Rows[i].Cells[0].Value.ToString().Trim();
            txtTenDV.Text = dtgDichVu.Rows[i].Cells[1].Value.ToString().Trim();
            txtGiaDV.Text = dtgDichVu.Rows[i].Cells[2].Value.ToString().Trim();
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaDV.Enabled = true;
            txtGiaDV.Enabled = true;
            txtTenDV.Enabled = true;
            btnThem.Enabled = false;
            chucnang = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (chucnang == true)
            {
                Them();
            }
            else
            {
                Luu();
            }
            Reset_data();
        }

        private void Luu()
        {
            try
            {
                if (txtMaDV.Text == "")
                {
                    txtMaDV.Focus();
                    MessageBox.Show("Bạn chưa nhập Mã Dịch Vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtTenDV.Text == "")
                {
                    txtTenDV.Focus();
                    MessageBox.Show("Bạn chưa nhập tên Dịch Vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtGiaDV.Text == "")
                {
                    txtGiaDV.Focus();
                    MessageBox.Show("Bạn chưa nhập giá dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string sql = "update DichVu set TenDV ='" + txtTenDV.Text.ToString().Trim() + "', " +
               "GiaDV='" + txtGiaDV.Text.ToString().Trim() + "'where MaDV ='" + txtMaDV.Text.ToString().Trim() + "'";
                DataProvider.Instance.ExecuteNonQuery(sql);
                Reset_data();
                dtgDichVu_load();
                MessageBox.Show("Đã lưu thành công!");

            }
            catch
            {
                MessageBox.Show("Chưa lưu được!! ");
            }
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string maDV = txtTK.Text.Trim();
            if (txtTK.Text == "")
            {
                MessageBox.Show("Bạn phải nhập Mã Dịch Vụ");
                txtTK.Focus();
                return;
            }
            DataTable dt = DataProvider.Instance.ExecuteQuery($"Select * from DichVu where MaDV = N'{maDV}'");
            foreach (DataRow item in dt.Rows)
            {
                txtMaDV.Text = item["MaDV"].ToString();
                txtTenDV.Text = item["TenDV"].ToString();
                txtGiaDV.Text = item["GiaDV"].ToString();
            }
            dtgDichVu.DataSource = dt;
        }

        private void txtGiaDV_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }
        void GetHeaderText()
        {
            dtgDichVu.Columns[0].HeaderText = "Mã Dịch Vụ";
            dtgDichVu.Columns[1].HeaderText = "Tên Dịch Vụ";
            dtgDichVu.Columns[2].HeaderText = "Giá Dịch Vụ";
        }
    }
}
