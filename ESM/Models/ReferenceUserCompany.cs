using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESM.Models
{
    public class ReferenceUserCompany
    {
        public Guid ID { get; set; }

        public Guid UserID { get; set; }
        public Guid CompanyID { get; set; }

        public ReferenceUserCompany()
        {
            ID = Guid.NewGuid();
          
        }
    }
}