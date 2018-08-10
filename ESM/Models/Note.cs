using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ESM.Models
{
    public class Note
    {
        public Guid NoteId { get; set; }
        [Display(Name = "Treść notatki: ")]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsInArchive { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public Note()
        {
            NoteId = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            IsInArchive = false;
        }
    }
}