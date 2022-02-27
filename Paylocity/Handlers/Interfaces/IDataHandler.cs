using Paylocity.Models;

namespace Paylocity.Handlers.Interfaces
{
    public interface IDataHandler
    {
        EmployeeDependentsResponse ProcessEmployeeDependentsRequest(EmployeeDependentsRequest request);
    }
}
