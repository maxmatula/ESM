using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESM.Models;


/// <summary>
/// Interfejs pobierający listę pracowników z bazy danych
/// </summary>

namespace ESM.Abstract
{
    interface IEmployeeList
    {
        IEnumerable<Employee> Employees { get; }
    }
}
