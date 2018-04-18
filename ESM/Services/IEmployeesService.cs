using ESM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESM.Services
{
    public interface IEmployeesService
    {
        bool Create(Employee employee, string currentCompanyId);
        bool Edit(Employee employee);
        bool Delete(Guid id);
    }
}
