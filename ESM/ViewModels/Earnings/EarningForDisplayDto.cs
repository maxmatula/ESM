using ESM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ESM.ViewModels.Earnings
{
    public class EarningForDisplayDto
    {
        public Guid EarningId { get; set; }

        public DateTime AddDate { get; set; }

        public decimal Ammount { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ChangeDate { get; set; }

        public Guid EmployeeId { get; set; }

        public Guid? AgreementId { get; set; }

        public List<PartialEarning> PartialEarnings { get; set; }
    }
}