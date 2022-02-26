using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paylocity.Models;

namespace Paylocity.Controllers
{
    public class BenefitsController : Controller
    {
        [HttpGet]
        public string Calculate(EmployeeDependents employee)
        {
            return "We are here");
        }
    }
}
