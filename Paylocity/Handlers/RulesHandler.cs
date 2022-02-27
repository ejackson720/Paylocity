using Paylocity.Handlers.Interfaces;

namespace Paylocity.Handlers
{
    public class RulesHandler: IRulesHandler
    {
        private const char DISCOUNTED_FIRST_LETTER = 'A';
        private const double ORIGINAL_COST_EMPLOYEE_ANNUAL = 1000;
        private const double ORIGINAL_COST_DEPENDENT_ANNUAL = 500;
        private const double PERCENT_DISCOUNT = .9;

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

        public double GetCostAnnual(string name, bool isDependent)
        {
            bool isDiscounted = IsDiscounted(name);

            if (isDependent)
            {
                return isDiscounted == false ? ORIGINAL_COST_DEPENDENT_ANNUAL : ORIGINAL_COST_DEPENDENT_ANNUAL * PERCENT_DISCOUNT;
            }


            return isDiscounted == false ? ORIGINAL_COST_EMPLOYEE_ANNUAL : ORIGINAL_COST_EMPLOYEE_ANNUAL * PERCENT_DISCOUNT;
        }
    }
}
