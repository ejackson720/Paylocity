
using Paylocity.Handlers.Interfaces;
using Paylocity.Models;

namespace Paylocity.Handlers
{
    public class DataHandler : IDataHandler
    {
        private readonly IPersonHandler _personHandler;

        public DataHandler( IPersonHandler personHandler)
        {
            _personHandler = personHandler;
        }

        public EmployeeDependentsResponse ProcessEmployeeDependentsRequest(EmployeeDependentsRequest request)
        {   
            if(request == null)
            {
                return new EmployeeDependentsResponse()
                {
                    HasError = true
                };
            }

            EmployeeDependentsResponse response = new();

            //Create a person for the employee
            var employeePerson= _personHandler.GetPerson(request.EmployeeName, false);
            if(employeePerson.Name.Length == 0)
            {
                response.HasError = true;
                return response;
            }
            response.People.Add(employeePerson);

            //Create a person for each dependent
            foreach(var dependent in request.Dependents)
            {
                var dependentPerson = _personHandler.GetPerson(dependent, true);
                if(dependentPerson.Name.Length == 0)
                {
                    response.HasError = true;
                    return response;
                }
                response.People.Add(dependentPerson);
            }

            return response;
         
        }

    }
}
