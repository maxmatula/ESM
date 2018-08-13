using ESM.DAL;
using ESM.Models;
using System;
using System.IO;
using System.Web;

namespace ESM.Services
{
    public class AgreementsService : IAgreementsService
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
            catch (Exception e)
            {
                return filepath = "";
                throw new Exception("Nie można odnaleźć pliku", e);
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
            catch (Exception e)
            {
                return false;
                throw new Exception("Error: ", e);
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
            catch (Exception e)
            {
                return returnPath = "";
                throw new Exception("File upload failed!", e);
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
