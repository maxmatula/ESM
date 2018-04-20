using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ESM.Services
{
    public class DirectoriesService : IDirectoriesService
    {
        public string GetDirectory(string id)
        {
            try
            {
                string userDirectory = "";
                string userId = id + "\\";
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
                throw new Exception("Directory error! Can't get user directory");
            }
            
        }
    }
}