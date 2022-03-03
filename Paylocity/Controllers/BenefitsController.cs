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
            string errorMsg = "Error processing this request. <br> If you feel you made a mistake, please re-enter the information. <br> Otherwise please contact the IT department";
            try
            {
                //Get the response
                var responseObject = _dataHandler.ProcessEmployeeDependentsRequest(employee);

                if (responseObject == null || responseObject.HasError)
                {
                    return errorMsg;
                }

                //Get the HTML
                string html = _hTMLHandler.GetHTML(responseObject);
                return html;
            }
            catch (Exception ex)
            {
                //This is where I would do some kind of alerting or logging (ex) to let the developers know something is wrong, then return a generic message
                return errorMsg;

            }
        }
    }
}
