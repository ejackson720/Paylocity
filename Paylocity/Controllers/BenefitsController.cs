using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paylocity.Handlers.Interfaces;
using Paylocity.Models;

namespace Paylocity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BenefitsController : Controller
    {
        private IDataHandler _dataHandler;

        public BenefitsController(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        [Route("Calculate")]
        [HttpPost]
        [HttpGet("{employee}")]
        public string Calculate(EmployeeDependentsRequest employee)
        {
            //Get the response
            var responseObject = _dataHandler.ProcessEmployeeDependentsRequest(employee);
            responseObject.HasError = true;

            if(responseObject.HasError)
            {
                return "Error processing this request. <br> If you feel you made a mistake, please reenter the information. <br> Otherwise please contact the IT department";
            }

            //
            return "We are here";
        }
    }
}
