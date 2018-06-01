using ESM.Models;
using ESM.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESM.Controllers
{
    [Authorize]
    public class CertyficationsController : Controller
    {
        private readonly IDirectoriesService _directoriesService;
        private readonly ICertyficationsService _certyficationsService;

        public CertyficationsController(IDirectoriesService directoriesService, ICertyficationsService certyficationsService)
        {
            _directoriesService = directoriesService;
            _certyficationsService = certyficationsService;
        }

        public ActionResult GetFile(Guid certyficationId)
        {
            var owner = _certyficationsService.UserIsFileOwner(certyficationId, User.Identity.GetUserId());
            if (owner == true)
            {
                var filepath = _certyficationsService.GetFile(certyficationId);
                if (System.IO.File.Exists(filepath))
                {
                    return File(filepath, "application/pdf");
                }
                return HttpNotFound();
            }
            return View("Error");
        }

        //GET
        public ActionResult AddCertyfication(Guid employeeId)
        {
            Certyfication certyfication = new Certyfication();
            certyfication.EmployeeId = employeeId;
            return View(certyfication);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCertyfication(Certyfication certyfication, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var employeeId = certyfication.EmployeeId;
                var userPath = _directoriesService.GetUserDirectory(User.Identity.GetUserId());
                var filePath = _certyficationsService.UploadCertyfication(userPath, file);
                var result = _certyficationsService.SaveCertyficationToDb(filePath, certyfication);
                return RedirectToAction("Details", "Employees", new { id = employeeId });
            }
            return View(certyfication);
        }
    }
}
