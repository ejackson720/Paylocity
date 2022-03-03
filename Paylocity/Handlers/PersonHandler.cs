using Paylocity.Handlers.Interfaces;
using Paylocity.Models;

namespace Paylocity.Handlers
{
    public class PersonHandler : IPersonHandler
    {
        readonly IRulesHandler _rulesHandler;
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
                IsDiscounted = _rulesHandler.IsDiscounted(name),
                IsEmployee = !isDependent
            };                

            return person;
        }

        public Person GetEmployee(EmployeeDependentsResponse response)
        {
            if (response == null)
            {
                throw new Exception("Invalid response in GetEmployee");
            }

            var employee = response.People.Where(x => x.IsEmployee == true).FirstOrDefault();
            if(employee == null)
            {
                throw new Exception("No Employee in dependents");
            }
            return employee;
        }                
    }
}
