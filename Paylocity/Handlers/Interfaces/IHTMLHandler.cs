using Paylocity.Models;

namespace Paylocity.Handlers.Interfaces
{
    public interface IHTMLHandler
    {
        string GetHTML(EmployeeDependentsResponse response);
    }
}
