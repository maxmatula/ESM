using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ESM.DAL;
using ESM.Models;
using ESM.ViewModels.Employees;

namespace ESM.Services
{
    public class EmployeesService : IEmployeesService
    {
        private ESMDbContext db = new ESMDbContext();
        public bool Create(Employee employee, string currentCompanyId, string picture)
        {
            try
            {
                employee.CompanyId = Guid.Parse(currentCompanyId);
                if (picture.Length > 10)
                {
                    var extension = picture.Substring(picture.IndexOf(':') + 1);
                    var extLength = extension.IndexOf(';');
                    var allLength = extension.Length - extLength;
                    extension = extension.Remove(extLength, allLength);

                    var file = picture.Substring(picture.IndexOf(',') + 1);

                    var bytes = Convert.FromBase64String(file);
                    employee.PictureMimeType = extension;
                    employee.PictureData = bytes;
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

        public bool Edit(Employee employee, string picture)
        {
            try
            {
                if (picture.Length > 10)
                {
                    var extension = picture.Substring(picture.IndexOf(':') + 1);
                    var extLength = extension.IndexOf(';');
                    var allLength = extension.Length - extLength;
                    extension = extension.Remove(extLength, allLength);

                    var file = picture.Substring(picture.IndexOf(',') + 1);

                    var bytes = Convert.FromBase64String(file);
                    employee.PictureMimeType = extension;
                    employee.PictureData = bytes;
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

        public EmployeeViewModel GetById(Guid id)
        {
            var employee = db.Employees.Find(id);
            var model = Mapper.Map<EmployeeViewModel>(employee);
            model.Earnings = employee.Earnings.OrderByDescending(x => x.AddDate).ToList();
            model.Agreements = employee.Agreements.OrderByDescending(x => x.AddDate).ToList();
            model.Certyfications = employee.Certyfications.OrderByDescending(x => x.AddDate).ToList();
            model.RecruitmentDocuments = employee.RecruitmentDocuments.OrderByDescending(x => x.AddDate).ToList();
            var earning = employee.Earnings.OrderByDescending(x => x.AddDate).FirstOrDefault();
            if(earning != null)
            {
                model.CurrentEarnings = earning.Ammount.ToString("c");
            }
            else
            {
                model.CurrentEarnings = "0";
            }
            return model;
        }
    }
}
