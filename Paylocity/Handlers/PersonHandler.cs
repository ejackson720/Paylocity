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
                return null;
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
                return null;
            }

            var employee  = response.People.Where(x => x.IsEmployee == true).FirstOrDefault();

            return employee;
        }

        public int GetNumberPeopleDiscounted(EmployeeDependentsResponse response)
        {
            return response.People.Where(x=>x.IsDiscounted == true).ToList().Count();
        }
        public int GetNumberOfDependents(EmployeeDependentsResponse response)
        {
            return response.People.Where(x => x.IsEmployee = false).ToList().Count();
        }

        public decimal GetAnnualCost(EmployeeDependentsResponse response)
        {

        }
    }
}
