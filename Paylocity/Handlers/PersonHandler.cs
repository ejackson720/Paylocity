using Paylocity.Handlers.Interfaces;
using Paylocity.Models;

namespace Paylocity.Handlers
{
    public class PersonHandler : IPersonHandler
    {
        IRulesHandler _rulesHandler;
        public PersonHandler(IRulesHandler rulesHandler)
        {
            _rulesHandler = rulesHandler;
        }

        public Person GetPerson(string name, bool isDependent)
        {
            if (name == null || name.Length == 0)
            {
                throw new Exception("Invalid Name");
            }

            var person = new Person()
            {
                Name = name,
                Cost = _rulesHandler.GetCostAnnual(name, isDependent),
                IsDiscounted = _rulesHandler.IsDiscounted(name)  ,
                IsEmployee = !isDependent
            };                

            return person;
        }

        public Person GetEmployee(EmployeeDependentsResponse response)
        {
            if (response == null )
            {
                throw new Exception("Invalid Response");
            }

            var employee  = response.People.Where(x => x.IsEmployee == true).FirstOrDefault();
            if(employee == null)
            {
                throw new Exception("No Employee");
            }
            return employee;
        }

        public int GetNumberPeopleDiscounted(EmployeeDependentsResponse response)
        {
            return response.People.Where(x=>x.IsDiscounted == true).ToList().Count();
        }

        public int GetNumberDependentsDiscounted(EmployeeDependentsResponse response)
        {
            return response.People.Where(x => x.IsDiscounted == true && x.IsEmployee == false).ToList().Count();
        }
        public int GetNumberOfDependents(EmployeeDependentsResponse response)
        {
            return response.People.Where(x => x.IsEmployee == false).ToList().Count();
        }

        public double GetAnnualCost(EmployeeDependentsResponse response)
        {
            return response.People.Select(x => x.Cost).Sum();
        }

        public string GetDependentNames(EmployeeDependentsResponse response)
        {
            return String.Join(",",response.People.Select(x => x.Name));
        }
    }
}
