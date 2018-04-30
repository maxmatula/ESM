using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ESM.DAL;
using ESM.Models;

namespace ESM.Services
{
    public class CertyficationsService : ICertyficationsService
    {
        private ESMDbContext db = new ESMDbContext();
        public string GetFile(Guid certyficationId)
        {
            string filepath = "";
            try
            {
                if (certyficationId != null)
                {
                    var certyfication = db.Certyfications.Find(certyficationId);
                    filepath = certyfication.FilePath.ToString();
                }
                return filepath;
            }
            catch (Exception)
            {
                return filepath = "";
                throw new Exception("Nie można odnaleźć pliku");
            }
        }

        public bool SaveCertyficationToDb(string uploadPath, Certyfication certyfication)
        {
            try
            {
                certyfication.FilePath = uploadPath;
                db.Certyfications.Add(certyfication);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public string UploadCertyfication(string userPath, HttpPostedFileBase file)
        {
            string returnPath = "";
            try
            {
                if (file.ContentLength > 0)
                {
                    string _fileName = Path.GetFileName(file.FileName);
                    string _uniqueFileName = string.Format(@"{0}", DateTime.Now.Ticks);
                    _fileName += _uniqueFileName;
                    returnPath = Path.Combine(userPath, _fileName);
                    file.SaveAs(returnPath);
                }
                return returnPath;

            }
            catch
            {
                return returnPath = "";
                throw new Exception("File upload failed!");
            }
        }

        public bool UserIsFileOwner(Guid certyficationId, string currentUserId)
        {
            var certyfication = db.Certyfications.Find(certyficationId);
            if (certyfication.FilePath.Contains(currentUserId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}