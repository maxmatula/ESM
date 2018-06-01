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

        private readonly IAgreementsService _agreementService;
        private readonly IEventsService _eventsService;
        private readonly IDirectoriesService _directoriesService;

        public AgreementsController(IAgreementsService agreementsService, IDirectoriesService directoriesService, IEventsService eventsService)
        {
            _agreementService = agreementsService;
            _directoriesService = directoriesService;
            _eventsService = eventsService;
        }

        public ActionResult GetFile(Guid agreementId)
        {
            var owner = _agreementService.UserIsFileOwner(agreementId, User.Identity.GetUserId());
            if (owner == true)
            {
                var filepath = _agreementService.GetFile(agreementId);
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
                if (agreement.EndDate != null)
                {
                    Event esmevent = new Event();
                    string companyId = Session["currentCompanyId"].ToString();
                    esmevent.EmployeeId = agreement.EmployeeId;
                    esmevent.CompanyId = Guid.Parse(companyId);
                    esmevent.Name = agreement.Description;
                    esmevent.Description = "Koniec umowy o pracę";
                    esmevent.EventDate = agreement.EndDate.Value;
                    var resultEvent = _eventsService.CreateEmployeeEvent(esmevent);
                }
                var employeeId = agreement.EmployeeId;
                var userPath = _directoriesService.GetUserDirectory(User.Identity.GetUserId());
                var filePath = _agreementService.UploadAgreement(userPath, file);
                var result = _agreementService.SaveAgreementToDb(filePath, agreement);
                return RedirectToAction("Details", "Employees", new { id = employeeId });
            }
            return View(agreement);
        }
    }
}