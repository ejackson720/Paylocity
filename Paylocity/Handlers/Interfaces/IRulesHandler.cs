
namespace Paylocity.Handlers.Interfaces
{
    public interface IRulesHandler
    {
        bool IsDiscounted(string name);
        double GetCostAnnual(string name, bool isDependent);
        string GetAnnualPay();
        string GetPayCheck();
        string GetPaycheckAfterDeductions(double annualDeductions);
    }
}
