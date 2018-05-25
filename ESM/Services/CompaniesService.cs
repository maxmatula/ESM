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
        public bool Create(Company company, UserCompanyRef userCompanyRef, string userId, string logo)
        {
            try
            {
                userCompanyRef.UserId = userId;
                userCompanyRef.CompanyId = company.CompanyId;

                if (logo != null)
                {
                    var extension = logo.Substring(logo.IndexOf(':') + 1);
                    var extLength = extension.IndexOf(';');
                    var allLength = extension.Length - extLength;
                    extension = extension.Remove(extLength, allLength);

                    var file = logo.Substring(logo.IndexOf(',') + 1);

                    var bytes = Convert.FromBase64String(file);
                    company.LogoMimeType = extension;
                    company.LogoData = bytes;
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

        public bool Edit(Company company, string logo)
        {
            try
            {
                if (logo != null)
                {
                    var extension = logo.Substring(logo.IndexOf(':') + 1);
                    var extLength = extension.IndexOf(';');
                    var allLength = extension.Length - extLength;
                    extension = extension.Remove(extLength, allLength);

                    var file = logo.Substring(logo.IndexOf(',') + 1);

                    var bytes = Convert.FromBase64String(file);
                    company.LogoMimeType = extension;
                    company.LogoData = bytes;
                }
                db.Entry(company).State = EntityState.Modified;
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
