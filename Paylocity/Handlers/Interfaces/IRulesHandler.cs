
namespace Paylocity.Handlers.Interfaces
{
    public interface IRulesHandler
    {
        bool IsDiscounted(string name);
        decimal GetCostAnnual(string name, bool isDependent);
    }
}
