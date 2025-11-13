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
    }
}