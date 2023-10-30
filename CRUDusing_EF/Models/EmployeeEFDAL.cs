using CRUDusing_EF.Data;
using CRUDusing_EF.Models;
using Microsoft.Data.SqlClient;

namespace CRUDusing_EF.Models
{
    public class EmployeeEFDAL
    {
        ApplicationDbContext db;
        public EmployeeEFDAL(ApplicationDbContext db)
        {
            this.db = db;
        }
        //get employee
        public IEnumerable<EmployeeEF> GetEmployeeEFs()
        {
            //linq
            var result = from b in db.EmpEF
                         select b;
            return result;

            //return db.EmpEF.ToList();
        }

        //getemp by id
        public EmployeeEF GetEmployeeEFById(int id)
        {
            //lambda
            var res = db.EmpEF.Where(x => x.Id == id).SingleOrDefault();
            return res;
        }

        //Add emp
        public int AddEmployeeEF(EmployeeEF emp)
        {
            db.EmpEF.Add(emp);
            int res = db.SaveChanges();
            return res;

        }
        //UpdateEmployeeEF
        public int UpdateEmployeeEF(EmployeeEF employeeEF)
        {
            int res = 0;

            var result = db.EmpEF.Where(x => x.Id == employeeEF.Id).FirstOrDefault();
            if (result != null)
            {
                result.Name = employeeEF.Name;
                result.Dept = employeeEF.Dept;
                result.Salary = employeeEF.Salary;

                res = db.SaveChanges();


            }
            return res;
        }

        //delete
        public int DeleteEmployeeEF(int id)
        {
            int res = 0;
            var result = db.EmpEF.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                db.EmpEF.Remove(result);
                res = db.SaveChanges();
            }
            return res;

        }
    }
}
