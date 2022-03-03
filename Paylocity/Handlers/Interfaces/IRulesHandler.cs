
namespace Paylocity.Handlers.Interfaces
{
    public interface IRulesHandler
    {
        bool IsDiscounted(string name);
        double GetCostAnnual(string name, bool isDependent);
        string GetPayCheckString();
        double GetPayCheckAnnual();
        double GetAnnualPay();        
        double GetNumPayChecks();
        

    }
}
