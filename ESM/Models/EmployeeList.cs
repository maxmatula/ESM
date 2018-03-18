///Klasa kontener dla klasy Employee
///Jej zadanie to opakowanie w liste objektów klasy Employee

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESM.Models
{
    public class EmployeeList : IEnumerable<Employee>
    {
        public List<Employee> Employees { get; set; }
        public IEnumerator<Employee> GetEnumerator()
        {
            return Employees.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}