using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPT.DTO
{
    class PhongDTO
    {
        public string maPhong { get; set; }
        public string tenPhong { get; set; }
        public int giaPhong { get; set; }
        public string trangThai { get; set; }

        public PhongDTO()
        {
            maPhong = "";
            tenPhong = "";
            giaPhong = 0;
            trangThai = "";
        }

        public PhongDTO(DataRow item)
        {
            this.maPhong = item["MaPhong"].ToString();
            this.tenPhong = item["TenPhong"].ToString();
            this.giaPhong = (int)item["GiaPhong"];
            this.trangThai = item["TrangThai"].ToString();

        }



    }
}
