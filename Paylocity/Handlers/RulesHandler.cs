using Paylocity.Handlers.Interfaces;

namespace Paylocity.Handlers
{
    public class RulesHandler: IRulesHandler
    {
        private const char DISCOUNTED_FIRST_LETTER = 'A';
        private const double ORIGINAL_COST_EMPLOYEE_ANNUAL = 1000;
        private const double ORIGINAL_COST_DEPENDENT_ANNUAL = 500;
        private const double PAYCHECK_TOTAL = 2000;
        private const double NUM_OF_PAYCHECK = 26;
        private const double PERCENT_DISCOUNT = .9;

        public bool IsDiscounted(string name)
        {
            if(name == null || name.Length == 0)
            {
                return false;
            }

            //the directions said 'A', personally I think it should have been 'A' or 'a' since you are supposed to start names capilized anyway
            // but I am sticking to the directions given to me, but I would ask the product owner if that is what they intended. 
            // if 'a' is allowed I would use a to upper on the char
            if (name[0] == DISCOUNTED_FIRST_LETTER) 
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
                return isDiscounted == false ? ORIGINAL_COST_DEPENDENT_ANNUAL : Math.Round(ORIGINAL_COST_DEPENDENT_ANNUAL * PERCENT_DISCOUNT, 2);
            }


            var costAnnual = isDiscounted == false ? ORIGINAL_COST_EMPLOYEE_ANNUAL : ORIGINAL_COST_EMPLOYEE_ANNUAL * PERCENT_DISCOUNT;
            return Math.Round(costAnnual, 2);
        }

        public double GetAnnualPay()
        {
            return Math.Round(PAYCHECK_TOTAL * NUM_OF_PAYCHECK, 2);
        }

        public string GetPayCheckString()
        {
            return PAYCHECK_TOTAL.ToString("N2");
        }

        public double GetPayCheckAnnual()
        {
            return PAYCHECK_TOTAL;
        }

        public double GetNumPayChecks()
        {
            return NUM_OF_PAYCHECK;
        }


    }
}
