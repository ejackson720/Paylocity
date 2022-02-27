using Paylocity.Handlers.Interfaces;

namespace Paylocity.Handlers
{
    public class RulesHandler: IRulesHandler
    {
        private const char DISCOUNTED_FIRST_LETTER = 'A';
        private const decimal ORIGINAL_COST_EMPLOYEE_ANNUAL = 1000;
        private const decimal ORIGINAL_COST_DEPENDENT_ANNUAL = 500;

        public bool IsDiscounted(string name)
        {
            if(name == null || name.Length == 0)
            {
                return false;
            }

            if(name[0] == DISCOUNTED_FIRST_LETTER)
            {
                return true;
            }

            return false;
        }

        public decimal GetCostAnnual(string name, bool isDependent)
        {
            bool isDiscounted = IsDiscounted(name);

            if (isDependent)
            {
                return ORIGINAL_COST_DEPENDENT_ANNUAL;
            }

            return ORIGINAL_COST_EMPLOYEE_ANNUAL;
        }
    }
}
