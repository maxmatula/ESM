using ESM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ESM.Services
{
    public interface IAgreementService
    {
        string UploadAgreement(string userPath, HttpPostedFileBase file);
        bool SaveAgreementToDb(string uploadPath, Agreement agreement);
        string GetFile(Guid agreementId);
    }
}
