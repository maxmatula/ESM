using ESM.DAL;
using ESM.Models;
using System;
using System.IO;
using System.Web;

namespace ESM.Services
{
    public class AgreementService : IAgreementService
    {
        private ESMDbContext db = new ESMDbContext();

        public string GetFile(Guid agreementId)
        {
            string filepath = "";
            try
            {
                if (agreementId != null)
                {
                    var agreement = db.Agreements.Find(agreementId);
                    filepath = agreement.FilePath.ToString();
                }
                return filepath;
            }
            catch (Exception)
            {
                return filepath = "";
                throw new Exception("Nie można odnaleźć pliku");
            }
        }

        public bool SaveAgreementToDb(string uploadPath, Agreement agreement)
        {
            try
            {
                agreement.FilePath = uploadPath;
                db.Agreements.Add(agreement);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public string UploadAgreement(string userPath, HttpPostedFileBase file)
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

        public bool UserIsFileOwner(Guid agreementId, string currentUserId)
        {

            var agreement = db.Agreements.Find(agreementId);
            if (agreement.FilePath.Contains(currentUserId))
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
