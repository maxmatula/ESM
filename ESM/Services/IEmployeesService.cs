using ESM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ESM.Services
{
    public interface IEmployeesService
    {
        bool Create(Employee employee, string currentCompanyId, HttpPostedFileBase picture);
        bool Edit(Employee employee, string currentCompanyId, HttpPostedFileBase picture);
        bool Delete(Guid id);
    }
}
