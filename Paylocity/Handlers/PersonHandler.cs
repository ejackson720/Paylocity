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
                IsDiscounted = _rulesHandler.IsDiscounted(name)                
            };           
           

            return person;
        }
    }
}
