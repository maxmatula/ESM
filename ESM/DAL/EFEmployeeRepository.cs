using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ESM.Abstract;
using ESM.Models;


/// <summary>
/// Repozytorium do pobierania danych z bazy danych implementujące interfejs IEmployeeList
/// </summary>
namespace ESM.DAL
{

    public class EFEmployeeRepository : IEmployeeList
    {
        private ESMContext context = new ESMContext();


        public IEnumerable<Employee> Employees
        {
            get { return context.Employees; }
        }
    }



}