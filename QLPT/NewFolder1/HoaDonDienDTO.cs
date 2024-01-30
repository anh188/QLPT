using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPT.DTO
{
    class HoaDonDienDTO
    {
        public string maHoaDonDien { get; set; }
        public string maPhong { get; set; }
        public string tenPhong { get; set; }
        public DateTime ngayTinhTien { get; set; }
        public int chiSoDienCu { get; set; }
        public int chiSoDienMoi { get; set; }
        public int chiSoDienSuDung { get; set; }
        public int giaDien { get; set; }
        public int tienDien { get; set; }

        public HoaDonDienDTO()
        {
            maHoaDonDien = "";
            maPhong = "";
            tenPhong = "";
            ngayTinhTien = DateTime.Now;
            chiSoDienCu = 0;
            chiSoDienMoi = 0;
            chiSoDienSuDung = 0;
            giaDien = 0;
            tienDien = 0;
        }

        public HoaDonDienDTO(DataRow item)
        {
            this.maHoaDonDien = item["MaHoaDonDien"].ToString();
            this.maPhong = item["MaPhong"].ToString();
            this.tenPhong = item["TenPhong"].ToString();
            this.ngayTinhTien = (DateTime)item["NgayTinhTien"];
            this.chiSoDienCu = (int)item["ChiSoDienCu"];
            this.chiSoDienMoi = (int)item["ChiSoDienMoi"];
            this.chiSoDienSuDung = (int)item["ChiSoDienSuDung"];
            this.giaDien = (int)item["GiaDien"];
            this.tienDien = (int)item["TienDien"];

        }

    }
}
