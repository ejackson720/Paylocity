using Paylocity.Handlers.Interfaces;
using Paylocity.Models;
using System.Text;

namespace Paylocity.Handlers
{
    public class HTMLHandler : IHTMLHandler
    {
        private IPersonHandler _personHandler;

        public HTMLHandler(IPersonHandler personHandler)
        {
            _personHandler = personHandler;
        }

        public string GetHTML(EmployeeDependentsResponse response)
        {
            StringBuilder stringBuilder = new StringBuilder();
            /*
            Need to include
            Employee Name
            #Of Dependents
            #Of 
            

             * */
            //get the employee 
            var employee = _personHandler.GetEmployee(response);
            if(employee == null)
            {
                return "Could not find employee";
            }

            stringBuilder.Append($"Report for Employee:{employee.Name}");
            stringBuilder.Append("<br/>");
            stringBuilder.Append("<br/>");
            stringBuilder.Append($"#Of Dependents:{_personHandler.GetNumberOfDependents(response)}"); //-1 since the employee is 
            stringBuilder.Append("<br/>");
            stringBuilder.Append($"#Of Dependents that are discounted:{_personHandler.GetNumberPeopleDiscounted(response)}");



            return "";
        }
    }
}
