using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ESM.Services
{
    public interface IDirectoriesService
    {
        string GetDirectory(string userId);
        string UploadFile(string userPath, HttpPostedFileBase file);
    }
}
