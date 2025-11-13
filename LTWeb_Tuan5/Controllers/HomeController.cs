using LTWeb_Tuan5.Models;
using System.Collections.Generic;
using System.Web.Mvc;

public class HomeController : Controller
{
    DuLieu csdl = new DuLieu(); 

    public ActionResult HienThiNhanVien()
    {
        List<Employee> ds = csdl.dsNV; 
        return View(ds); 
    }

    public ActionResult HienThiPhongBan()
    {
        List<Department> dsPB = csdl.LayDsPhongBan();
        return View(dsPB);
    }

    public ActionResult ChiTietPhongBan(int id)
    {
        Department pb = csdl.LayDsPhongBan().Find(p => p.MaPB == id);
        return View(pb);
    }

    public ActionResult NhanVienTheoPhong(int id)
    {
        List<Employee> dsNVLoc = csdl.LayDsNhanVienTheoPhong(id);

        ViewBag.TenPhong = csdl.LayDsPhongBan().Find(p => p.MaPB == id).TenPB;

        return View("HienThiNhanVien", dsNVLoc);
    }
}