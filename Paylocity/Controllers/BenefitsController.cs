using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paylocity.Models;

namespace Paylocity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BenefitsController : Controller
    {
        [Route("Calculate")]
        [HttpPost]
        [HttpGet("{employee}")]
        public string Calculate(EmployeeDependents employee)
        {
            return "We are here";
        }
    }
}
