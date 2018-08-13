using ESM.DAL;
using ESM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESM.Controllers
{
    public class NotesController : Controller
    {
        private readonly ESMDbContext _context;

        public NotesController(ESMDbContext context)
        {
            _context = context;
        }

        public ActionResult NotesListArchive(Guid? employeeId)
        {
            if (employeeId == null)
            {
                return HttpNotFound();
            }

            var notes = _context.Notes.Where(x => x.EmployeeId == employeeId.Value && x.IsInArchive == true).ToList();

            if (notes == null)
            {
                return HttpNotFound();
            }

            ViewBag.EmployeeId = employeeId.Value;

            return View(notes);
        }

        // GET: Notes
        public ActionResult AddNote(Guid? employeeId)
        {
            if (employeeId == null)
            {
                return HttpNotFound();
            }

            var note = new Note();
            note.EmployeeId = employeeId.Value;
            return View(note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNote(Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Notes.Add(note);
                _context.SaveChanges();
                return RedirectToAction("Details", "Employees", new { id = note.EmployeeId });
            }

            return View(note);
        }

        public ActionResult EditNote(Guid? noteId)
        {
            if (noteId == null)
            {
                return HttpNotFound();
            }

            var note = _context.Notes.Find(noteId.Value);

            if (note == null)
            {
                return HttpNotFound();
            }

            return View(note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditNote(Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(note).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Details", "Employees", new { id = note.EmployeeId });
            }

            return View(note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult MoveToArchive(Guid? noteId)
        {
            if (noteId == null)
            {
                return HttpNotFound();
            }

            var note = _context.Notes.Find(noteId.Value);

            if (note == null)
            {
                return HttpNotFound();
            }

            note.IsInArchive = true;
            _context.Entry(note).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Details", "Employees", new { id = note.EmployeeId });
        }
    }
}