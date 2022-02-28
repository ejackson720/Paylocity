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
        private IHTMLHandler _hTMLHandler;

        public BenefitsController(IDataHandler dataHandler, IHTMLHandler hTMLHandler)
        {
            _dataHandler = dataHandler;
            _hTMLHandler = hTMLHandler;
        }

        [Route("Calculate")]
        [HttpPost]
        [HttpGet("{employee}")]
        public string Calculate(EmployeeDependentsRequest employee)
        {
            try
            {
                //Get the response
                var responseObject = _dataHandler.ProcessEmployeeDependentsRequest(employee);

                if (responseObject.HasError)
                {
                    return "Error processing this request. <br> If you feel you made a mistake, please reenter the information. <br> Otherwise please contact the IT department";
                }

                //Get the HTML
                string html = _hTMLHandler.GetHTML(responseObject);
                return html;
            }
            catch (Exception ex)
            {
                return "Error processing this request. <br> If you feel you made a mistake, please reenter the information. <br> Otherwise please contact the IT department";

            }
        }
    }
}
