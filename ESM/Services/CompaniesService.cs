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
        public bool Create(Company company, UserCompanyRef userCompanyRef, string userId, HttpPostedFileBase logo)
        {
            try
            {
                userCompanyRef.UserId = userId;
                userCompanyRef.CompanyId = company.CompanyId;

                if (logo != null)
                {
                    company.LogoMimeType = logo.ContentType;
                    company.LogoData = new byte[logo.ContentLength];
                    logo.InputStream.Read(company.LogoData, 0, logo.ContentLength);
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

        public bool Edit(Company company, UserCompanyRef userCompanyRef, HttpPostedFileBase logo)
        {
            try
            {
                if (logo != null)
                {
                    company.LogoMimeType = logo.ContentType;
                    company.LogoData = new byte[logo.ContentLength];
                    logo.InputStream.Read(company.LogoData, 0, logo.ContentLength);
                }
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
