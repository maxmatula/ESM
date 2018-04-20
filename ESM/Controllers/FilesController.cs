using ESM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ESM.Services;
using Microsoft.AspNet.Identity;

namespace ESM.Controllers
{
    public class FilesController : Controller
    {
        private readonly ESMDbContext db;
        private readonly IDirectoriesService directoriesService;

        public FilesController()
        {
            this.db = new ESMDbContext();
            this.directoriesService = new DirectoriesService();
        }

        // GET: Files
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            string userPath = directoriesService.GetDirectory(User.Identity.GetUserId());
            string filePath = directoriesService.UploadFile(userPath, file);
            if (filePath.Length > 0)
            {
                ViewBag.Message = "Upload Success!";
            }
            else
            {
                ViewBag.Message = "Upload Error!";
            }
            return View();
        }

    }
}