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
        public bool Create(Employee employee, string currentCompanyId, HttpPostedFileBase picture)
        {
            try
            {
                employee.CompanyId = Guid.Parse(currentCompanyId);
                if (picture != null)
                {
                    employee.PictureMimeType = picture.ContentType;
                    employee.PictureData = new byte[picture.ContentLength];
                    picture.InputStream.Read(employee.PictureData, 0, picture.ContentLength);
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

        public bool Edit(Employee employee, string currentCompanyId, HttpPostedFileBase picture)
        {

            try
            {
                employee.CompanyId = Guid.Parse(currentCompanyId);
                if (picture != null)
                {
                    employee.PictureMimeType = picture.ContentType;
                    employee.PictureData = new byte[picture.ContentLength];
                    picture.InputStream.Read(employee.PictureData, 0, picture.ContentLength);
                }
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