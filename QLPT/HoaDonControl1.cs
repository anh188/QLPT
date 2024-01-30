using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLPT
{
    public partial class HoaDonControl1 : UserControl
    {
        public HoaDonControl1()
        {
            InitializeComponent();
        }
        string strCon = @"Data Source=DESKTOP-HR0MVSB\SQLEXPRESS;Initial Catalog = quanlynhatro; Integrated Security = True
        //Doi tuong ket noi
        SqlConnection sqlCon = null;

        //ham mo ket noi
        private void MoKetNoi()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }




        //ham dong ket noi
        private void DongKetNoi()
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }

        ////ham hien thi danh sach
        private void HienThiDanhSachHD()
        {
            MoKetNoi();

            //doi tuong thuc thi truy van
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "HienThiDanhSachHD";

            //Gan vao ket noi
            sqlCmd.Connection = sqlCon;

            //Thuc thi truy van
            SqlDataReader reader = sqlCmd.ExecuteReader();
            lsvDanhSachHD.Items.Clear();
            while (reader.Read())
            {
                //Doc du lieu trong CSDL
                string MaHoaDon = reader.GetString(0);
                string MaPhong = reader.GetString(1);
                string TenPhong = reader.GetString(2);
                string NgayThanhToan = reader.GetDateTime(3).ToString("MM/dd/yyyy");
                int GiaPhong = reader.GetInt32(4);
                int TienDien = reader.GetInt32(5);
                int TienNuoc = reader.GetInt32(6);
                int GiaDichVu = reader.GetInt32(7);
                int NoCu = reader.GetInt32(8);
                int TongTien = reader.GetInt32(9);
                int DaThanhToan = reader.GetInt32(10);
                int ConNo = reader.GetInt32(11);

                //Tao 1 dong du lieu moi tren listview
                ListViewItem lvi = new ListViewItem(MaHoaDon);
                lvi.SubItems.Add(MaPhong);
                lvi.SubItems.Add(TenPhong);
                lvi.SubItems.Add(NgayThanhToan);
                lvi.SubItems.Add(GiaPhong.ToString()); //Chuyen gia tri int thanh chuoi
                lvi.SubItems.Add(TienDien.ToString());
                lvi.SubItems.Add(TienNuoc.ToString());
                lvi.SubItems.Add(GiaDichVu.ToString());
                lvi.SubItems.Add(NoCu.ToString());
                lvi.SubItems.Add(TongTien.ToString());
                lvi.SubItems.Add(DaThanhToan.ToString());
                lvi.SubItems.Add(ConNo.ToString());

                //gan dong  du lieu len listview
                lsvDanhSachHD.Items.Add(lvi);

            }

            reader.Close();


        }



        ////Ham vo hieu hoa thong tin chi tiet
        private void DisableHD()
        {
            txtMaHoaDon.Enabled = false;
            txtMaPhong.Enabled = false;
            txtTenPhong.Enabled = false;
            dtpNgayThanhToan.Enabled = false;
            txtGiaphong.Enabled = false;
            txtTienDien.Enabled = false;
            txtTienNuoc.Enabled = false;
            txtGiaDichVu.Enabled = false;
            txtNoCu.Enabled = false;
            txtTongTien.Enabled = false;
            txtDaThanhToan.Enabled = false;
            txtConNo.Enabled = false;
        }

        //Ham huy bo vo hieu hoa
        private void EnabledHD()
        {
            txtMaHoaDon.Enabled = true;
            txtMaPhong.Enabled = true;
            txtTenPhong.Enabled = true;
            dtpNgayThanhToan.Enabled = true;
            txtGiaphong.Enabled = true;
            txtTienDien.Enabled = true;
            txtTienNuoc.Enabled = true;
            txtGiaDichVu.Enabled = true;
            txtNoCu.Enabled = true;
            //txtTongTien.Enabled = true;
            txtDaThanhToan.Enabled = true;
            //txtConNo.Enabled = true;
        }

        //Ham xoa dư lieu
        private void DeleteConTrolHD()
        {
            txtMaHoaDon.Text = txtMaPhong.Text = txtTenPhong.Text = txtGiaphong.Text = txtTienDien.Text = txtTienNuoc.Text = txtGiaDichVu.Text = txtNoCu.Text = txtTongTien.Text = txtDaThanhToan.Text = txtConNo.Text = "";
        }

        private void HoaDonControl1_Load(object sender, EventArgs e)
        {
            HienThiDanhSachHD();
            DisableHD();

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

        }
        //private void HoaDonControl1_Load(object sender, EventArgs e)
        //{
        //    HienThiDanhSachHD();
        //    DisableHD();

        //    btnSua.Enabled = false;
        //    btnXoa.Enabled = false;
        //    btnLuu.Enabled = false;
        //    btnHuy.Enabled = false;

        //    cbPhong.Item.Add("101");
        //    cbPhong.Item.Add("102");
        //    cbPhong.Item.Add("103");
        //    cbPhong.SelectedIndex = 0;

        //}


        //ham tim kiem theo ma
        private void TimKiemTheoMaHD(string tkmaHD)
        {
            MoKetNoi();
            //doi tuong thuc thi truy van
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "TimKiemTheoMaHD";

            //Dinh nghia paramter
            SqlParameter parMa = new SqlParameter("@ma", SqlDbType.Char);
            parMa.Value = tkmaHD;
            sqlCmd.Parameters.Add(parMa);

            //Gan vao ket noi
            sqlCmd.Connection = sqlCon;

            //Thuc thi truy van
            SqlDataReader reader = sqlCmd.ExecuteReader();
            lsvDanhSachHD.Items.Clear();
            if (reader.Read())
            {
                //Doc du lieu trong CSDL
                string MaHoaDon = reader.GetString(0);
                string MaPhong = reader.GetString(1);
                string TenPhong = reader.GetString(2);
                string NgayThanhToan = reader.GetDateTime(3).ToString("MM/dd/yyyy");
                int GiaPhong = reader.GetInt32(4);
                int TienDien = reader.GetInt32(5);
                int TienNuoc = reader.GetInt32(6);
                int GiaDichVu = reader.GetInt32(7);
                int NoCu = reader.GetInt32(8);
                int TongTien = reader.GetInt32(9);
                int DaThanhToan = reader.GetInt32(10);
                int ConNo = reader.GetInt32(11);

                //Tao 1 dong du lieu moi tren listview
                ListViewItem lvi = new ListViewItem(MaHoaDon);
                lvi.SubItems.Add(MaPhong);
                lvi.SubItems.Add(TenPhong);
                lvi.SubItems.Add(NgayThanhToan);
                lvi.SubItems.Add(GiaPhong.ToString()); //Chuyen gia tri int thanh chuoi
                lvi.SubItems.Add(TienDien.ToString());
                lvi.SubItems.Add(TienNuoc.ToString());
                lvi.SubItems.Add(GiaDichVu.ToString());
                lvi.SubItems.Add(NoCu.ToString());
                lvi.SubItems.Add(TongTien.ToString());
                lvi.SubItems.Add(DaThanhToan.ToString());
                lvi.SubItems.Add(ConNo.ToString());

                //gan dong  du lieu len listview
                lsvDanhSachHD.Items.Add(lvi);
            }
            reader.Close();
        }

        private void TimKiemTheoTenPhong(string tenPhong)
        {
            MoKetNoi();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "TimKiemTheoTenPhong";

            SqlParameter parTenPhong = new SqlParameter("@tenPhong", SqlDbType.NVarChar);
            parTenPhong.Value = tenPhong;
            sqlCmd.Parameters.Add(parTenPhong);

            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            lsvDanhSachHD.Items.Clear();

            while (reader.Read())
            {
                // Lấy dữ liệu từ CSDL tương tự như trong hàm TimKiemTheoMaHD
                // ...

                // Thêm vào ListView tương tự như trong hàm TimKiemTheoMaHD
                // ...

            }

            reader.Close();
        }


        // Ham xoa sinh vien
        private void XoaHoaDon(string MaHD_d)
        {
            MoKetNoi();

            //Doi tuong thuc thi truy van
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "XoaHD";

            //dinh nghia paramter
            SqlParameter parMa = new SqlParameter("@maHD", SqlDbType.VarChar);
            parMa.Value = maHD_d;
            sqlCmd.Parameters.Add(parMa);

            //Gan vao ket noi
            sqlCmd.Connection = sqlCon;

            //thuc thi truy van
            int kq = sqlCmd.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Xoá hóa đơn thành công!");
                HienThiDanhSachHD();
            }
            else
            {
                MessageBox.Show("Xóa hóa đơn không thành công!");
            }

        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tkmaHD = txtTimKiem.Text.Trim();
            if (tkmaHD == "")
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn để tìm kiếm!");

            }
            else
            {
                TimKiemTheoMaHD(tkmaHD);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            EnabledHD();

            cn = 1;
            //txtTongTien.Enabled = false;
            //txtConNo.Enabled = false;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cn == 1)
            {
                //Lay dl tu Giao dien
                string maHD = txtMaHoaDon.Text.Trim();
                string maPhong = txtMaPhong.Text.Trim();
                string tenPhong = txtTenPhong.Text.Trim();  // Thêm điều khiển TextBox cho tên phòng
                DateTime ngayThanhToan = DateTime.Now.Date;  // Thay bằng giá trị thực từ DatePicker hoặc điều khiển ngày tháng
                int giaPhong = Convert.ToInt32(txtGiaphong.Text);  // Thay bằng giá trị từ TextBox cho giá phòng
                int tienDien = Convert.ToInt32(txtTienDien.Text);
                int tienNuoc = Convert.ToInt32(txtTienNuoc.Text);
                int giaDichVu = Convert.ToInt32(txtGiaDichVu.Text);
                int noCu = Convert.ToInt32(txtTongTien.Text);
                //int tongTien = Convert.ToInt32(txtTongTien.Text);
                int daThanhToan = Convert.ToInt32(txtDaThanhToan.Text);
                //int conNo = Convert.ToInt32(txtConNo.Text);

                MoKetNoi();

                //Doi tuong thuc thi truy van
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "ThemHoaDon";

                //Dinh nghia parameter
                SqlParameter parMaHD = new SqlParameter("@maHD", SqlDbType.Char);
                SqlParameter parMaPhong = new SqlParameter("@maPhong", SqlDbType.Char);
                SqlParameter parTenPhong = new SqlParameter("@tenPhong", SqlDbType.Char);
                SqlParameter parNgayThanhToan = new SqlParameter("@ngayThanhToan", SqlDbType.Date);
                SqlParameter parGiaPhong = new SqlParameter("@giaPhong", SqlDbType.Int);
                SqlParameter parTienDien = new SqlParameter("@tienDien", SqlDbType.Int);
                SqlParameter parTienNuoc = new SqlParameter("@tienNuoc", SqlDbType.Int);
                SqlParameter parGiaDichVu = new SqlParameter("@giaDichVu", SqlDbType.Int);
                SqlParameter parNoCu = new SqlParameter("@noCu", SqlDbType.Int);
                //SqlParameter parTongTien = new SqlParameter("@tongTien", SqlDbType.Int);
                SqlParameter parDaThanhToan = new SqlParameter("@daThanhToan", SqlDbType.Int);
                //SqlParameter parConNo = new SqlParameter("@conNo", SqlDbType.Int);

                // Gán giá trị cho các parameter từ các điều kiện trong ứng dụng của bạn
                parMaHD.Value = maHD;
                parMaPhong.Value = maPhong;
                parTenPhong.Value = tenPhong;
                parNgayThanhToan.Value = ngayThanhToan;
                parGiaPhong.Value = giaPhong;
                parTienDien.Value = tienDien;
                parTienNuoc.Value = tienNuoc;
                parGiaDichVu.Value = giaDichVu;
                parNoCu.Value = noCu;
                //parTongTien.Value = tongTien;
                parDaThanhToan.Value = daThanhToan;
                //parConNo.Value = conNo;

                // Thêm các parameter vào đối tượng SqlCommand
                sqlCmd.Parameters.Add(parMaHD);
                sqlCmd.Parameters.Add(parMaPhong);
                sqlCmd.Parameters.Add(parTenPhong);
                sqlCmd.Parameters.Add(parNgayThanhToan);
                sqlCmd.Parameters.Add(parGiaPhong);
                sqlCmd.Parameters.Add(parTienDien);
                sqlCmd.Parameters.Add(parTienNuoc);
                sqlCmd.Parameters.Add(parGiaDichVu);
                sqlCmd.Parameters.Add(parNoCu);
                //sqlCmd.Parameters.Add(parTongTien);
                sqlCmd.Parameters.Add(parDaThanhToan);
                //sqlCmd.Parameters.Add(parConNo);

                // gan vao ket noi
                sqlCmd.Connection = sqlCon;

                //Thuc thi truy van
                int kq = sqlCmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Thêm hóa đơn thành công!");
                    HienThiDanhSachHD();
                }
                else
                {
                    MessageBox.Show("Thêm hóa đơn thất bại!");
                }

                //DongKetNoi();
            }
            else if (cn == 2)
            {
                //Lay dl tu Giao dien
                string maHD = txtMaHoaDon.Text.Trim();
                string maPhong = txtMaPhong.Text.Trim();
                string tenPhong = txtTenPhong.Text.Trim();  // Thêm điều khiển TextBox cho tên phòng
                DateTime ngayThanhToan = DateTime.Now.Date;  // Thay bằng giá trị thực từ DatePicker hoặc điều khiển ngày tháng
                int giaPhong = Convert.ToInt32(txtGiaphong.Text);  // Thay bằng giá trị từ TextBox cho giá phòng
                int tienDien = Convert.ToInt32(txtTienDien.Text);
                int tienNuoc = Convert.ToInt32(txtTienNuoc.Text);
                int giaDichVu = Convert.ToInt32(txtGiaDichVu.Text);
                int noCu = Convert.ToInt32(txtNoCu.Text);
                //int tongTien = Convert.ToInt32(txtTongTien.Text);
                int daThanhToan = Convert.ToInt32(txtDaThanhToan.Text);
                //int conNo = Convert.ToInt32(txtConNo.Text);

                MoKetNoi();

                //Doi tuong thuc thi truy van
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "ChinhSuaHoaDon";

                //Dinh nghia parameter
                SqlParameter parMaHD = new SqlParameter("@maHD", SqlDbType.Char);
                SqlParameter parMaPhong = new SqlParameter("@maPhong", SqlDbType.Char);
                SqlParameter parTenPhong = new SqlParameter("@tenPhong", SqlDbType.Char);
                SqlParameter parNgayThanhToan = new SqlParameter("@ngayThanhToan", SqlDbType.Date);
                SqlParameter parGiaPhong = new SqlParameter("@giaPhong", SqlDbType.Int);
                SqlParameter parTienDien = new SqlParameter("@tienDien", SqlDbType.Int);
                SqlParameter parTienNuoc = new SqlParameter("@tienNuoc", SqlDbType.Int);
                SqlParameter parGiaDichVu = new SqlParameter("@giaDichVu", SqlDbType.Int);
                SqlParameter parNoCu = new SqlParameter("@noCu", SqlDbType.Int);
                //SqlParameter parTongTien = new SqlParameter("@tongTien", SqlDbType.Int);
                SqlParameter parDaThanhToan = new SqlParameter("@daThanhToan", SqlDbType.Int);
                //SqlParameter parConNo = new SqlParameter("@conNo", SqlDbType.Int);

                // Gán giá trị cho các parameter từ các điều kiện trong ứng dụng của bạn
                parMaHD.Value = maHD;
                parMaPhong.Value = maPhong;
                parTenPhong.Value = tenPhong;
                parNgayThanhToan.Value = ngayThanhToan;
                parGiaPhong.Value = giaPhong;
                parTienDien.Value = tienDien;
                parTienNuoc.Value = tienNuoc;
                parGiaDichVu.Value = giaDichVu;
                parNoCu.Value = noCu;
                //parTongTien.Value = tongTien;
                parDaThanhToan.Value = daThanhToan;
                //parConNo.Value = conNo;

                // Thêm các parameter vào đối tượng SqlCommand
                sqlCmd.Parameters.Add(parMaHD);
                sqlCmd.Parameters.Add(parMaPhong);
                sqlCmd.Parameters.Add(parTenPhong);
                sqlCmd.Parameters.Add(parNgayThanhToan);
                sqlCmd.Parameters.Add(parGiaPhong);
                sqlCmd.Parameters.Add(parTienDien);
                sqlCmd.Parameters.Add(parTienNuoc);
                sqlCmd.Parameters.Add(parGiaDichVu);
                sqlCmd.Parameters.Add(parNoCu);
                //sqlCmd.Parameters.Add(parTongTien);
                sqlCmd.Parameters.Add(parDaThanhToan);
                //sqlCmd.Parameters.Add(parConNo);

                // gan vao ket noi
                sqlCmd.Connection = sqlCon;

                //Thuc thi truy van
                int kq = sqlCmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Sửa hóa đơn thành công!");
                    HienThiDanhSachHD();
                    //btnHuy.Enabled= false;
                    //btnLuu.Enabled= false;
                }
                else
                {
                    MessageBox.Show("Sửa hóa đơn thất bại!");
                }
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DeleteConTrolHD();
            DisableHD();
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = true;
        }

        //Lay ra ma hoa don can xoa
        string maHD_d = "";

        private void lsvDanhSachHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDanhSachHD.SelectedItems.Count == 0) return;

            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            //fill DL HoaDon
            ListViewItem lvi = lsvDanhSachHD.SelectedItems[0];

            txtMaHoaDon.Text = maHD_d = lvi.SubItems[0].Text;
            txtMaPhong.Text = lvi.SubItems[1].Text;
            txtTenPhong.Text = lvi.SubItems[2].Text;
            String[] dt = lvi.SubItems[3].Text.Split('/');
            dtpNgayThanhToan.Value = new DateTime(Int32.Parse(dt[2]), Int32.Parse(dt[0]), Int32.Parse(dt[1]));

            txtGiaphong.Text = lvi.SubItems[4].Text;
            txtTienDien.Text = lvi.SubItems[5].Text;
            txtTienNuoc.Text = lvi.SubItems[6].Text;
            txtGiaDichVu.Text = lvi.SubItems[7].Text;
            txtNoCu.Text = lvi.SubItems[8].Text;
            // Assuming you have a method to fetch the total amount from the database
            txtTongTien.Text = lvi.SubItems[9].Text;
            txtDaThanhToan.Text = lvi.SubItems[10].Text;
            txtConNo.Text = lvi.SubItems[11].Text;

        }

        //Bien ktra dang thuc hien chuc nang gi
        int cn = 0;

        private void btnSua_Click(object sender, EventArgs e)
        {
            EnabledHD();
            cn = 2;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa hóa đơn này không", "Hộp thoại", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                XoaHoaDon(maHD_d);
            }
            else
            {
                btnXoa.Enabled = false;
            }
        }
    }
}
