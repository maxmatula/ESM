using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESM.Models
{
    public class ReferenceUserCompany
    {
        public Guid ID { get; set; }

        public string UserID { get; set; }
        public string CompanyID { get; set; }

        public ReferenceUserCompany()
        {
            ID = Guid.NewGuid();
          
        }
    }
}