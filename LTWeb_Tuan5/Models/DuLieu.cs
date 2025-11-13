using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; 
using System.Configuration; 
using LTWeb_Tuan5.Models;

namespace LTWeb_Tuan5.Models
{
    public class DuLieu
    {
        string strcon = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        public List<Employee> dsNV = new List<Employee>(); 


        public DuLieu()
        {
            ThietLap_DSNV(); 
        }

        public void ThietLap_DSNV() 
        {
            SqlConnection con = new SqlConnection(strcon);

            string sql = "select * from tbl_Employee"; 

            SqlDataAdapter da = new SqlDataAdapter(sql, con); 

            DataTable dt = new DataTable(); 

            da.Fill(dt); 

            
            foreach (DataRow dr in dt.Rows) 
            {
                var em = new Employee(); 

                em.MaNV = int.Parse(dr["Id"].ToString()); 
                em.Ten = dr["Name"].ToString(); 
                em.GioiTinh = dr["Gender"].ToString(); 
                em.Tinh = dr["City"].ToString(); 
                em.MaPg = (int)dr["DeptId"];

                dsNV.Add(em);
            }
        }
        public List<Department> LayDsPhongBan()
        {
            List<Department> dsPB = new List<Department>();
            SqlConnection con = new SqlConnection(strcon);

            string sql = "SELECT d.Deptid, d.Name, COUNT(e.Id) AS SoNV " +
                         "FROM tbl_Deparment d " +
                         "LEFT JOIN tbl_Employee e ON d.Deptid = e.Deptid " +
                         "GROUP BY d.Deptid, d.Name";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                dsPB.Add(new Department
                {
                    MaPB = (int)dr["Deptid"],
                    TenPB = dr["Name"].ToString(),
                    SoNV = (int)dr["SoNV"]
                });
            }
            return dsPB;
        }

        public List<Employee> LayDsNhanVienTheoPhong(int maPhong)
        {
            List<Employee> dsNVLoc = new List<Employee>();
            SqlConnection con = new SqlConnection(strcon);

            string sql = "SELECT * FROM tbl_Employee WHERE Deptid = @maPhong";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            da.SelectCommand.Parameters.AddWithValue("@maPhong", maPhong);

            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                dsNVLoc.Add(new Employee
                {
                    MaNV = int.Parse(dr["Id"].ToString()),
                    Ten = dr["Name"].ToString(),
                    GioiTinh = dr["Gender"].ToString(),
                    Tinh = dr["City"].ToString(),
                    MaPg = (int)dr["DeptId"]
                });
            }
            return dsNVLoc;
        }
    }
}