using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ESM.Services
{
    public class DirectoriesService : IDirectoriesService
    {
        public string GetDirectory(string userId)
        {
            try
            {
                string userDirectory = "";
                userId = userId + "\\";
                string physicalPath = HttpRuntime.AppDomainAppPath;
                physicalPath = physicalPath.Replace("ESM\\", "UserFiles\\");
                userDirectory = Path.Combine(physicalPath, userId);

                if (!Directory.Exists(userDirectory))
                {
                    Directory.CreateDirectory(userDirectory);
                }

                return userDirectory;
            }
            catch
            {
                throw new Exception("Directory error! Can't get user directory!");
            }

        }

        public string UploadFile(string userPath, HttpPostedFileBase file)
        {
            string returnPath = "";
            try
            {
                if (file.ContentLength > 0)
                {
                    string _fileName = Path.GetFileName(file.FileName);
                    returnPath = Path.Combine(userPath, _fileName);
                    file.SaveAs(returnPath);
                }
                return returnPath;
            }
            catch
            {
                returnPath = "";
                throw new Exception("File upload failed!");
            }
        }
    }
}