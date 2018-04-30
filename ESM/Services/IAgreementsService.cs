using ESM.Models;
using System;
using System.Web;

namespace ESM.Services
{
    public interface IAgreementsService
    {
        string UploadAgreement(string userPath, HttpPostedFileBase file);
        bool SaveAgreementToDb(string uploadPath, Agreement agreement);
        string GetFile(Guid agreementId);
        bool UserIsFileOwner(Guid agreementId, string currentUserId);
    }
}
