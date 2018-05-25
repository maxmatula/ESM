using ESM.Models;
using ESM.ViewModels.Employees;
using System;
using System.Web;

namespace ESM.Services
{
    public interface IEmployeesService
    { 
        EmployeeViewModel GetById(Guid id);
        bool Create(Employee employee, string currentCompanyId, string picture);
        bool Edit(Employee employee, string currentCompanyId, string picture);
        bool Delete(Guid id);
    }
}
