
using Paylocity.Handlers.Interfaces;
using Paylocity.Models;

namespace Paylocity.Handlers
{
    public class DataHandler : IDataHandler
    {
        private IPersonHandler _personHandler;

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

            //Create a person for the original employee
            response.Employee = _personHandler.GetPerson(request.EmployeeName, false);

            //Create a person for each dependent
            foreach(var dependent in request.Dependents)
            {
                response.Dependents.Add(_personHandler.GetPerson(dependent, true));
            }

            return response;
         
        }

    }
}
