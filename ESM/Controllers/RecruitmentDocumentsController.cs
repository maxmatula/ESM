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
    public class RecruitmentDocumentsController : Controller
    {
        private readonly DirectoriesService directoriesService;
        private readonly RecruitmentDocumentsService recruitmentDocumentsService;
        public RecruitmentDocumentsController()
        {
            this.directoriesService = new DirectoriesService();
            this.recruitmentDocumentsService = new RecruitmentDocumentsService();
        }

        public ActionResult GetFile(Guid recruitmentId)
        {
            var owner = recruitmentDocumentsService.UserIsFileOwner(recruitmentId, User.Identity.GetUserId());
            if (owner == true)
            {
                var filepath = recruitmentDocumentsService.GetFile(recruitmentId);
                if (System.IO.File.Exists(filepath))
                {
                    return File(filepath, "application/pdf");
                }
                return HttpNotFound();
            }
            return View("Error");
        }

        //GET
        public ActionResult AddRecruitmentDocument(Guid employeeId)
        {
            RecruitmentDocument recruitment = new RecruitmentDocument();
            recruitment.EmployeeId = employeeId;
            return View(recruitment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRecruitmentDocument(RecruitmentDocument recruitment, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var employeeId = recruitment.EmployeeId;
                var userPath = directoriesService.GetUserDirectory(User.Identity.GetUserId());
                var filePath = recruitmentDocumentsService.UploadRecruitment(userPath, file);
                var result = recruitmentDocumentsService.SaveRecruitmentToDb(filePath, recruitment);
                return RedirectToAction("Details", "Employees", new { id = employeeId });
            }
            return View(recruitment);
        }
    }
}
