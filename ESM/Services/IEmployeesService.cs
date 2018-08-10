using ESM.Models;
using ESM.ViewModels.Employees;
using System;
using System.Linq;

namespace ESM.Services
{
    public interface IEmployeesService
    { 
        EmployeeViewModel GetById(Guid id);
        Employee GetEmployeeById(Guid id);
        IQueryable<Employee> GetEmployees(Guid companyId);
        IQueryable<Employee> SearchEmployees(string searchString, IQueryable<Employee> employees);
        bool Create(Employee employee, string currentCompanyId, string picture);
        bool Edit(Employee employee, string picture);
        bool MoveToArchive(Guid id);
        bool Restore(Guid id);
    }
}
