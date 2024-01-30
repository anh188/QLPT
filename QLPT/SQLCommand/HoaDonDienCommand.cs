using QLPT.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPT.SQLCommand
{
    class HoaDonDienCommand
    {

        // Lấy danh sách hóa đơn điện
        public List<HoaDonDienDTO> GetListHoaDonDien()
        {
            List<HoaDonDienDTO> listHoaDonDien = new List<HoaDonDienDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from HoaDonDien");

            foreach (DataRow item in data.Rows)
            {
                HoaDonDienDTO dg = new HoaDonDienDTO(item);

                listHoaDonDien.Add(dg);
            }

            return listHoaDonDien;
        }

        public bool ThemHoaDonDien(HoaDonDienDTO hoaDonDienDTO)
        {

            string query = "insert into HoaDonDien(MaHoaDonDien, MaPhong, TenPhong, NgayTinhTien, ChiSoDienCu, ChiSoDienMoi, ChiSoDienSuDung, GiaDien, TienDien) values ('" + hoaDonDienDTO.maHoaDonDien + "'" +
                   ",'" + hoaDonDienDTO.maPhong + "','" + hoaDonDienDTO.tenPhong + "','" + hoaDonDienDTO.ngayTinhTien+ "',"+ hoaDonDienDTO.chiSoDienCu+ "," + hoaDonDienDTO.chiSoDienMoi + "," + 
                   hoaDonDienDTO.chiSoDienSuDung + "," + hoaDonDienDTO.giaDien + "," + hoaDonDienDTO.tienDien +")";
            int rerult = DataProvider.Instance.ExecuteNonQuery(query);

            return rerult>0;
        }

        public bool SuaHoaDonDien(HoaDonDienDTO hoaDonDienDTO)
        {

            string query = "update HoaDonDien set  NgayTinhTien = '"+ hoaDonDienDTO.ngayTinhTien +"', ChiSoDienCu ="+ hoaDonDienDTO.chiSoDienCu + ", ChiSoDienMoi = " + hoaDonDienDTO.chiSoDienMoi +"," +
                " ChiSoDienSuDung = "+ hoaDonDienDTO.chiSoDienSuDung+", GiaDien = "+ hoaDonDienDTO.giaDien+", TienDien ="+ hoaDonDienDTO.tienDien +"where MaHoaDonDien = '" + hoaDonDienDTO.maHoaDonDien + "'";
            int rerult = DataProvider.Instance.ExecuteNonQuery(query);

            return rerult > 0;
        }

        public bool XoaHoaDonDien(string id)
        {
            string query = "Delete HoaDonDien where MaHoaDonDien = '"+id+"'";

            int rerult = DataProvider.Instance.ExecuteNonQuery(query);
            return rerult > 0;

        }

        public List<HoaDonDienDTO> TimTheoMaPhong(string idPhong)
        {
            List<HoaDonDienDTO> listHD = new List<HoaDonDienDTO>();

            string query = string.Format("select * from HoaDonDien where MaPhong = '{0}'", idPhong);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                HoaDonDienDTO type = new HoaDonDienDTO(item);

                listHD.Add(type);
            }

            return listHD;
        }
    }
}
