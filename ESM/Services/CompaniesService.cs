using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ESM.DAL;
using ESM.Models;

namespace ESM.Services
{
    public class CompaniesService : ICompaniesService
    {
        private ESMDbContext db = new ESMDbContext();
        public bool Create(Company company, UserCompanyRef userCompanyRef, string userId)
        {
            try
            {
                var newCompanyid = Guid.NewGuid();
                var existingCompaniesId = db.Companies.Select(x => x.CompanyId);
                if (existingCompaniesId.Contains(newCompanyid))
                {
                    newCompanyid = Guid.NewGuid();
                }
                else
                {
                    company.CompanyId = newCompanyid;
                }

                var newReferenceId = Guid.NewGuid();
                var existingReferencesId = db.UserCompanyRefs.Select(x => x.RefId);
                if (existingReferencesId.Contains(newReferenceId))
                {
                    newReferenceId = Guid.NewGuid();
                }
                else
                {
                    userCompanyRef.RefId = newReferenceId;
                }
                
                userCompanyRef.UserId = userId;
                userCompanyRef.CompanyId = company.CompanyId;

                if (company.Logo == null)
                {
                    company.Logo = "http://placehold.jp/200x200.png";
                }

                db.Companies.Add(company);
                db.UserCompanyRefs.Add(userCompanyRef);
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
                Company company = db.Companies.Find(id);
                var refid = db.UserCompanyRefs.Where(x => x.CompanyId.Equals(company.CompanyId)).Select(x => x.RefId);
                UserCompanyRef userCompanyRef = db.UserCompanyRefs.Find(refid);
                db.Companies.Remove(company);
                db.UserCompanyRefs.Remove(userCompanyRef);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(Company company, UserCompanyRef userCompanyRef)
        {
            try
            {
                db.Entry(company).State = EntityState.Modified;
                db.Entry(userCompanyRef).State = EntityState.Unchanged;
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
