using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESM.Models;

namespace ESM.Services
{
    public interface ICompaniesService
    {
        bool Create(Company company, UserCompanyRef userCompanyRef, string userId);
        bool Edit(Company company, UserCompanyRef userCompanyRef);
        bool Delete(Guid id);
    }
}
