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
}