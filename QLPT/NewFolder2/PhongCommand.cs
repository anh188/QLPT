using QLPT.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPT.SQLCommand
{
    class PhongCommand
    {
        public List<PhongDTO> GetListPhong()
        {
            List<PhongDTO> listP = new List<PhongDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Phong");

            foreach (DataRow item in data.Rows)
            {
                PhongDTO p = new PhongDTO(item);

                listP.Add(p);
            }

            return listP;
        }

        public List<PhongDTO> SearchByID(string id)
        {
            List<PhongDTO> listP = new List<PhongDTO>();

            string query = string.Format("select * from Phong where MaPhong = N'{0}'", id);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                PhongDTO type = new PhongDTO(item);

                listP.Add(type);
            }

            return listP;
        }
    }
}
