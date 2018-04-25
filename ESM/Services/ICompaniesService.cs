using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ESM.Models;

namespace ESM.Services
{
    public interface ICompaniesService
    {
        bool Create(Company company, UserCompanyRef userCompanyRef, string userId, HttpPostedFileBase logo);
        bool Edit(Company company, UserCompanyRef userCompanyRef, HttpPostedFileBase logo);
        bool Delete(Guid id);
    }
}
