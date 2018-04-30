using ESM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ESM.Services
{
    public interface ICertyficationsService
    {
        string UploadCertyfication(string userPath, HttpPostedFileBase file);
        bool SaveCertyficationToDb(string uploadPath, Certyfication certyfication);
        string GetFile(Guid certyficationId);
        bool UserIsFileOwner(Guid certyficationId, string currentUserId);
    }
}
