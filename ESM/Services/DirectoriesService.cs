using ESM.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ESM.Services
{
    public class DirectoriesService : IDirectoriesService
    {
        public string GetUserDirectory(string userId)
        {
            try
            {
                string userDirectory = "";
                userId = userId + "\\";
                string physicalPath = HttpContext.Current.Server.MapPath("~/App_Data/UserFiles/");
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
    }
}