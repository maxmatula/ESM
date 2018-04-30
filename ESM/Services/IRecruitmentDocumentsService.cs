using ESM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ESM.Services
{
    public interface IRecruitmentDocumentsService
    {
        string UploadRecruitment(string userPath, HttpPostedFileBase file);
        bool SaveRecruitmentToDb(string uploadPath, RecruitmentDocument recruitment);
        string GetFile(Guid recruitmentId);
        bool UserIsFileOwner(Guid recruitmentId, string currentUserId);
    }
}
