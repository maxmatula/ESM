using ESM.Models;
using ESM.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web;
using System.Web.Mvc;

namespace ESM.Controllers
{
    [Authorize]
    public class AgreementsController : Controller
    {

        private readonly AgreementsService agreementService;
        private readonly DirectoriesService directoriesService;

        public AgreementsController()
        {
            this.agreementService = new AgreementsService();
            this.directoriesService = new DirectoriesService();
        }

        public ActionResult GetFile(Guid agreementId)
        {
            var owner = agreementService.UserIsFileOwner(agreementId, User.Identity.GetUserId());
            if (owner == true)
            {
                var filepath = agreementService.GetFile(agreementId);
                if (System.IO.File.Exists(filepath))
                {
                    return File(filepath, "application/pdf");
                }
                return HttpNotFound();
            }
            return View("Error");
        }

        //GET
        public ActionResult AddAgreement(Guid employeeId)
        {
            Agreement agreement = new Agreement();
            agreement.EmployeeId = employeeId;
            return View(agreement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAgreement(Agreement agreement, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var employeeId = agreement.EmployeeId;
                var userPath = directoriesService.GetUserDirectory(User.Identity.GetUserId());
                var filePath = agreementService.UploadAgreement(userPath, file);
                var result = agreementService.SaveAgreementToDb(filePath, agreement);
                return RedirectToAction("Details", "Employees", new { id = employeeId });
            }

            return View(agreement);
        }
    }
}