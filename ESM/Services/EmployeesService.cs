using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ESM.DAL;
using ESM.Models;

namespace ESM.Services
{
    public class EmployeesService : IEmployeesService
    {
        private ESMDbContext db = new ESMDbContext();
        public bool Create(Employee employee, string currentCompanyId)
        {
            try
            {
                var newEmployeeId = Guid.NewGuid();
                var existingEmployeesId = db.Employees.Select(x => x.EmployeeId);
                if (existingEmployeesId.Contains(newEmployeeId))
                {
                    newEmployeeId = Guid.NewGuid();
                }
                else
                {
                    employee.EmployeeId = newEmployeeId;
                }
                employee.CompanyId = Guid.Parse(currentCompanyId);

                if (employee.Picture == null)
                {
                    employee.Picture = "http://placehold.jp/200x200.png";
                }
                db.Employees.Add(employee);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                Employee employee = db.Employees.Find(id);
                db.Employees.Remove(employee);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(Employee employee, string currentCompanyId)
        {
            try
            {
                employee.CompanyId = Guid.Parse(currentCompanyId);
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}