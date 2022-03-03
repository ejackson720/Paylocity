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
         
            var employee = _personHandler.GetEmployee(response);
            if(employee.Name.Length == 0)
            {
                throw new Exception("Could not find employee");
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
            stringBuilder.Append($"<td>{response.GetNumberOfDependents()} :   ({response.GetDependentNames()})</td>");
            stringBuilder.Append("</tr>");

            stringBuilder.Append("<tr>");
            stringBuilder.Append($"<td>#Of People that are discounted</td>");
            stringBuilder.Append($"<td>{response.GetNumberPeopleDiscounted()}</td>");
            stringBuilder.Append("</tr>");

            stringBuilder.Append("<tr>");
            stringBuilder.Append($"<td>Annual Cost of Insurance</td>");
            stringBuilder.Append($"<td>${response.GetAnnualCostSTring()}</td>");
            stringBuilder.Append("</tr>");

            stringBuilder.Append("<tr>");
            stringBuilder.Append($"<td>Cost of Insurance per Paycheck</td>");
            stringBuilder.Append($"<td>${response.GetCostPaycheck(_rulesHandler.GetNumPayChecks())}</td>");
            stringBuilder.Append("</tr>");

            stringBuilder.Append("<tr>");
            stringBuilder.Append($"<td>Paycheck After Deductions</td>");
            stringBuilder.Append($"<td>${response.GetPaycheckAfterDeductions(_rulesHandler.GetAnnualPay(), _rulesHandler.GetNumPayChecks())}</td>");
            stringBuilder.Append("</tr>");

            stringBuilder.Append("<tr>");
            stringBuilder.Append("</tr>");        

            stringBuilder.Append("</table>");
            return stringBuilder.ToString();
        }
    }
}
