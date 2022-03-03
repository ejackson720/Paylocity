
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
            ValidateRequest(request);

            EmployeeDependentsResponse response = new();

            //Create a person for the employee
            var employeePerson = _personHandler.GetPerson(request.EmployeeName, false);
            if(employeePerson.Name.Length == 0)
            {
                response.HasError = true;
                return response;
            }
            response.People.Add(employeePerson);

            //Just in case they typed in a person twice
            request.Dependents = request.Dependents.Distinct().ToList();

            //Create a person for each dependent
            foreach (var dependent in request.Dependents)
            {
                if (dependent == null || dependent.Length == 0)
                {
                    continue;
                }
                
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

        public void ValidateRequest(EmployeeDependentsRequest request)
        {
            if (request == null)
            {
                throw new Exception("EmployeeDependentsRequest is Null");
            }
            
            if(request.EmployeeName == null || request.EmployeeName.Length == 0)
            {
                throw new Exception("Employee Name is Null");
            }
            
            if(request.Dependents == null)
            {
                request.Dependents = new List<string>();
            }
        }

    }
}
