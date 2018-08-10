using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using ESM.DAL;
using ESM.Models;
using ESM.ViewModels.Earnings;
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

        public bool MoveToArchive(Guid id)
        {
            try
            {
                Employee employee = db.Employees.Find(id);
                employee.IsInArchive = true;
                employee.MoveToArchiveTime = DateTime.Now;
                db.Entry(employee).State = EntityState.Modified;
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
            var employee = db.Employees.Include(y => y.Earnings.Select(g => g.PartialEarnings)).FirstOrDefault(x => x.EmployeeId == id);
            var model = Mapper.Map<EmployeeViewModel>(employee);
            var earningsData = employee.Earnings.OrderByDescending(x => x.AddDate).ToList();
            model.Earnings = Mapper.Map<List<EarningForDisplayDto>>(earningsData);
            model.Agreements = employee.Agreements.OrderByDescending(x => x.AddDate).ToList();
            model.Certyfications = employee.Certyfications.OrderByDescending(x => x.AddDate).ToList();
            model.RecruitmentDocuments = employee.RecruitmentDocuments.OrderByDescending(x => x.AddDate).ToList();
            model.Notes = employee.Notes.Where(y => y.IsInArchive == false).OrderByDescending(x => x.CreatedAt).ToList();
            var earning = employee.Earnings.OrderByDescending(x => x.ChangeDate).FirstOrDefault();

            foreach (var earn in model.Earnings)
            {
                earn.SelectAgreements = model.Agreements.Where(x => x.EarningId == null).ToList();
            }

            if (earning == null)
            {
                model.CurrentEarnings = 0.ToString("c");
            }
            else
            {
                model.CurrentEarnings = earning.PartialEarnings.Sum(x => x.Ammount).ToString("c");
            }

            return model;
        }

        public bool Restore(Guid id)
        {
            try
            {
                Employee employee = db.Employees.Find(id);
                employee.IsInArchive = false;
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<Employee> GetEmployees(Guid companyId)
        {
            var employees = db.Employees.Where(x => x.CompanyId == companyId);

            return employees;                
        }

        public IQueryable<Employee> SearchEmployees(string searchString, IQueryable<Employee> employees)
        {
            var filteredEmployees = employees.Where(x => x.Name.Contains(searchString)
                    || x.Surname.Contains(searchString)
                    || x.Title.Contains(searchString));

            return filteredEmployees;
        }

        public Employee GetEmployeeById(Guid id)
        {
            var employee = db.Employees.FirstOrDefault(x => x.EmployeeId == id);

            return employee;
        }
    }
}
