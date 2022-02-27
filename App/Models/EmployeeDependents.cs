using System.Collections.Generic;

namespace App.Models
{
    public class EmployeeDependents
    {
        public string EmployeeName { get; set; }
        public List<string> Dependents { get; set; }

        public EmployeeDependents()
        {
            Dependents = new List<string>(); ;
        }

    }
}
