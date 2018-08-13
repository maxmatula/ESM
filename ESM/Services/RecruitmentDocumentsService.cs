using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ESM.DAL;
using ESM.Models;

namespace ESM.Services
{
    public class RecruitmentDocumentsService : IRecruitmentDocumentsService
    {
        private ESMDbContext db = new ESMDbContext();
        public string GetFile(Guid recruitmentId)
        {
            string filepath = "";
            try
            {
                if (recruitmentId != null)
                {
                    var recruitment = db.RecruitmentDocuments.Find(recruitmentId);
                    filepath = recruitment.FilePath.ToString();
                }
                return filepath;
            }
            catch (Exception e)
            {
                return filepath = "";
                throw new Exception("Nie można odnaleźć pliku", e);
            }
        }

        public bool SaveRecruitmentToDb(string uploadPath, RecruitmentDocument recruitment)
        {
            try
            {
                recruitment.FilePath = uploadPath;
                db.RecruitmentDocuments.Add(recruitment);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception("Error: ", e);
            }
        }

        public string UploadRecruitment(string userPath, HttpPostedFileBase file)
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

        public bool UserIsFileOwner(Guid recruitmentId, string currentUserId)
        {
            var recruitment = db.RecruitmentDocuments.Find(recruitmentId);
            if (recruitment.FilePath.Contains(currentUserId))
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