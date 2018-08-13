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
                if (logo.Length > 10)
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

                userCompanyRef.UserId = userId;
                userCompanyRef.CompanyId = company.CompanyId;

                db.Companies.Add(company);
                db.UserCompanyRefs.Add(userCompanyRef);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception("Error: ", e);
            }

        }

        public bool Delete(Guid id)
        {
            try
            {
                Company company = db.Companies.Find(id);
                db.Companies.Remove(company);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception("Error: ", e);
            }
        }

        public bool Edit(Company company, string logo)
        {
            try
            {
                if (logo.Length > 10)
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
            catch (Exception e)
            {
                return false;
                throw new Exception("Error: ", e);
            }


        }

        public Company FindByid(Guid id)
        {
            var company = db.Companies.FirstOrDefault(x => x.CompanyId == id);

            return company;
        }
    }
}
