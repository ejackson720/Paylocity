using App.Models;
using System.Threading.Tasks;

namespace App.Endpoints
{
    public interface IEndpoint
    {
        Task<string> CalculateBenefits(EmployeeDependents employeeBenefits);
        Task<string> SubmitToApi();
    }
}
