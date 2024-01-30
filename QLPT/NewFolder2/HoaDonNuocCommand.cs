using QLPT.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPT.SQLCommand
{
    class HoaDonNuocCommand
    {
        public List<HoaDonNuoc> GetListHoaDonNuoc()
        {
            List<HoaDonNuoc> listHoaDonDien = new List<HoaDonNuoc>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from HoaDonNuoc");

            foreach (DataRow item in data.Rows)
            {
                HoaDonNuoc dg = new HoaDonNuoc(item);

                listHoaDonDien.Add(dg);
            }

            return listHoaDonDien;
        }

        public bool ThemHoaDonNuoc(HoaDonNuoc hoaDonNuocDTO)
        {

            string query = "insert into HoaDonNuoc(MaHoaDonNuoc, MaPhong, TenPhong, NgayTinhTien, ChiSoNuocCu, ChiSoNuocMoi, ChiSoNuocSuDung, GiaNuoc, TienNuoc) values ('" + hoaDonNuocDTO.maHoaDonNuoc + "'" +
                   ",'" + hoaDonNuocDTO.maPhong + "','" + hoaDonNuocDTO.tenPhong + "','" + hoaDonNuocDTO.ngayTinhTien + "'," + hoaDonNuocDTO.chiSoNuocCu + "," + hoaDonNuocDTO.chiSoNuocMoi + "," +
                   hoaDonNuocDTO.chiSoNuocSuDung + "," + hoaDonNuocDTO.giaNuoc + "," + hoaDonNuocDTO.tienNuoc + ")";
            int rerult = DataProvider.Instance.ExecuteNonQuery(query);

            return rerult > 0;
        }

        public bool SuaHoaDonNuoc(HoaDonNuoc hoaDonNuocDTO)
        {

            string query = "update HoaDonNuoc set  NgayTinhTien = '" + hoaDonNuocDTO.ngayTinhTien + "', ChiSoNuocCu =" + hoaDonNuocDTO.chiSoNuocCu + ", ChiSoNuocMoi = " + hoaDonNuocDTO.chiSoNuocMoi + "," +
                " ChiSoNuocSuDung = " + hoaDonNuocDTO.chiSoNuocSuDung + ", GiaNuoc = " + hoaDonNuocDTO.giaNuoc + ", TienNuoc =" + hoaDonNuocDTO.tienNuoc + "where MaHoaDonNuoc = '" + hoaDonNuocDTO.maHoaDonNuoc + "'";
            int rerult = DataProvider.Instance.ExecuteNonQuery(query);

            return rerult > 0;
        }

        public bool XoaHoaDonNuoc(string id)
        {
            string query = "Delete HoaDonNuoc where MaHoaDonNuoc = '" + id + "'";

            int rerult = DataProvider.Instance.ExecuteNonQuery(query);
            return rerult > 0;

        }

        public List<HoaDonNuoc> TimTheoHoaDonNuoc(string idHoaDonNuoc)
        {
            List<HoaDonNuoc> listHD = new List<HoaDonNuoc>();

            string query = string.Format("select * from HoaDonNuoc where MaHoaDonNuoc = '{0}'", idHoaDonNuoc);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                HoaDonNuoc type = new HoaDonNuoc(item);

                listHD.Add(type);
            }

            return listHD;
        }
    }
}
