using Microsoft.AspNetCore.Mvc;
using Vu_DbFrist.Models;

namespace Vu_DbFrist.Controllers
{
   
    public class Main : Controller
    {
        public DbCompanyManagerDbfirstContext db = new DbCompanyManagerDbfirstContext();
        public IActionResult Index()
        {
            var result = from st in db.Staff
                         join de in db.Departments on st.DepartmentId equals de.DepartmentId
                         join co in db.Companies  on de.CompanyId equals co.CompanyId
                         where st.Age >= 30 && st.Age <= 40  && (de.Departmentname == null ? de.Departmentname != null : de.Departmentname == "Marketing") && (st.Gender == null ? st.Gender != null : st.Gender == "Nam")
                         select new {
                            StaffId = st.StaffId,
                            StaffName = st.Staffname,
                            Gender = st.Gender,
                            Age = st.Age,
                             Salary = st.Salary,
                             DepartmentName = de.Departmentname
                         };


            ViewBag.Inf = result.ToList();
            return View();
        }
    }
}
