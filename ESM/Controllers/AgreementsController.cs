using ESM.Models;
using ESM.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web;
using System.Web.Mvc;

namespace ESM.Controllers
{
    public class AgreementsController : Controller
    {

        private readonly AgreementService agreementService;
        private readonly DirectoriesService directoriesService;

        public AgreementsController()
        {
            this.agreementService = new AgreementService();
            this.directoriesService = new DirectoriesService();
        }

        public ActionResult GetFile(Guid agreementId)
        {
            var filepath = agreementService.GetFile(agreementId);
            return File(filepath, "application/pdf");
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