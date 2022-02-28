using Paylocity.Handlers.Interfaces;
using Paylocity.Models;
using System.Text;

namespace Paylocity.Handlers
{
    public class HTMLHandler : IHTMLHandler
    {
        private IPersonHandler _personHandler;
        private IRulesHandler _rulesHandler;

        public HTMLHandler(IPersonHandler personHandler, IRulesHandler rulesHandler)
        {
            _personHandler = personHandler;
            _rulesHandler = rulesHandler;
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
            stringBuilder.Append("<table>");
            stringBuilder.Append("<tr>");
            stringBuilder.Append($"<th>Benefits Breakdown for {employee.Name}</th>");
            stringBuilder.Append("<th></th>");            
            stringBuilder.Append("</tr>");

            stringBuilder.Append("<tr>");
            stringBuilder.Append($"<td></td>");
            stringBuilder.Append($"<td></td>");
            stringBuilder.Append("</tr>");

            stringBuilder.Append("<tr>");
            stringBuilder.Append($"<td>#Of Dependents</td>");
            stringBuilder.Append($"<td>{_personHandler.GetNumberOfDependents(response)}</td>");
            stringBuilder.Append("</tr>");

            stringBuilder.Append("<tr>");
            stringBuilder.Append($"<td>#Of Dependents that are discounted</td>");
            stringBuilder.Append($"<td>{_personHandler.GetNumberPeopleDiscounted(response)}</td>");
            stringBuilder.Append("</tr>");

            stringBuilder.Append("<tr>");
            stringBuilder.Append($"<td>Annual Cost of Insurance</td>");
            stringBuilder.Append($"<td>${_personHandler.GetAnnualCost(response)}</td>");
            stringBuilder.Append("</tr>");

            stringBuilder.Append("<tr>");
            stringBuilder.Append($"<td>Paycheck After Deductions</td>");
            stringBuilder.Append($"<td>${_rulesHandler.GetPaycheckAfterDeductions(_personHandler.GetAnnualCost(response))}</td>");
            stringBuilder.Append("</tr>");

            stringBuilder.Append("<tr>");
            stringBuilder.Append("</tr>");

            //stringBuilder.Append($"Report for Employee: {employee.Name}");
            //stringBuilder.Append("<br/>");
            //stringBuilder.Append("<br/>");
            //stringBuilder.Append($"#Of Dependents: {_personHandler.GetNumberOfDependents(response)}"); //-1 since the employee is 
            //stringBuilder.Append("<br/>");
            //stringBuilder.Append($"#Of Dependents that are discounted: {_personHandler.GetNumberPeopleDiscounted(response)}");
            //stringBuilder.Append("<br/>");
            //stringBuilder.Append($"Annual Cost: {_personHandler.GetAnnualCost(response)}");


            stringBuilder.Append("</table>");
            return stringBuilder.ToString();
        }
    }
}
