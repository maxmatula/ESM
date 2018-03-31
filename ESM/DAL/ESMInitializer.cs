using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ESM.Models;

namespace ESM.DAL
{
    public class ESMInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ESMContext>
    {
        protected override void Seed(ESMContext context)
        {
           
        }
    }
}