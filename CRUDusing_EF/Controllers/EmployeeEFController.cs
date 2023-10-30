using CRUDusing_EF.Data;
using CRUDusing_EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDusing_EF.Controllers
{
    public class EmployeeEFController : Controller
    {
        ApplicationDbContext context;
        EmployeeEFDAL db;

        public EmployeeEFController(ApplicationDbContext context)
        {
            this.context = context;
            db = new EmployeeEFDAL(this.context);
        }



        // GET: EmployeeEFController
        public ActionResult Index()
        {
            return View(db.GetEmployeeEFs());
        }

        // GET: EmployeeEFController/Details/5
        public ActionResult Details(int id)
        {
            var emp = db.GetEmployeeEFById(id);
            return View(emp);

        }

        // GET: EmployeeEFController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeEFController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeEF employeeEF)
        {
            try
            {
                int result = db.AddEmployeeEF(employeeEF);
                if (result >= 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeEFController/Edit/5
        public ActionResult Edit(int id)
        {
            var emp = db.GetEmployeeEFById(id);
            return View(emp);
        }

        // POST: EmployeeEFController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeEF employeeEF)
        {
            try
            {
                int result = db.UpdateEmployeeEF(employeeEF);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeEFController/Delete/5
        public ActionResult Delete(int id)
        {
            var emp = db.GetEmployeeEFById(id);
            return View();
        }

        // POST: EmployeeEFController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = db.DeleteEmployeeEF(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }
    }

}
