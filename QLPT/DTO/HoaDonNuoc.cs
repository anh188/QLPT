using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPT.DTO
{
    class HoaDonNuoc
    {
        public string maHoaDonNuoc { get; set; }
        public string maPhong { get; set; }
        public string tenPhong { get; set; }
        public DateTime ngayTinhTien { get; set; }
        public int chiSoNuocCu { get; set; }
        public int chiSoNuocMoi { get; set; }
        public int chiSoNuocSuDung { get; set; }
        public int giaNuoc { get; set; }
        public int tienNuoc { get; set; }

        public HoaDonNuoc()
        {
            maHoaDonNuoc = "";
            maPhong = "";
            tenPhong = "";
            ngayTinhTien = DateTime.Now;
            chiSoNuocCu = 0;
            chiSoNuocMoi = 0;
            chiSoNuocSuDung = 0;
            giaNuoc = 0;
            tienNuoc = 0;
        }

        public HoaDonNuoc(DataRow item)
        {
            this.maHoaDonNuoc = item["MaHoaDonNuoc"].ToString();
            this.maPhong = item["MaPhong"].ToString();
            this.tenPhong = item["TenPhong"].ToString();
            this.ngayTinhTien = (DateTime)item["NgayTinhTien"];
            this.chiSoNuocCu = (int)item["ChiSoNuocCu"];
            this.chiSoNuocMoi = (int)item["ChiSoNuocMoi"];
            this.chiSoNuocSuDung = (int)item["ChiSoNuocSuDung"];
            this.giaNuoc = (int)item["GiaNuoc"];
            this.tienNuoc = (int)item["TienNuoc"];
        }
    }
}
