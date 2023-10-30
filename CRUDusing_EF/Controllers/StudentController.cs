using CRUDusing_EF.Models;
using CRUDusing_EF.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDusing_EF.Controllers
{
    public class StudentController : Controller
    {
        ApplicationDbContext context;
        StudentDAL db;

        public StudentController(ApplicationDbContext context)
        {
            this.context = context;
            db = new StudentDAL(this.context);
        }

        // GET: StudentController
        public ActionResult Index()
        {
            return View(db.GetStudents());
    
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var student = db.GetStudentById(id);
            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {

                int result = db.AddStudent(student);
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

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var student = db.GetStudentById(id);
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {

                int result = db.UpdateStudent(student);
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

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = db.GetStudentById(id);
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {

                int result = db.DeleteStudent(id);
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
